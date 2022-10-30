using Parsec.Helpers;

namespace Parsec.Shaiya.Data;

public static class DataPatcher
{
    private static BinaryReader _patchBinaryReader;
    private static BinaryWriter _targetBinaryWriter;

    /// <summary>
    /// Applies the patches in the patch list into a target data
    /// </summary>
    /// <param name="targetData">Data where to apply the patches</param>
    /// <param name="patchDataList">Patches to apply</param>
    public static void Patch(Data targetData, params Data[] patchDataList)
    {
        try
        {
            // Create binary writer instance for the target saf file
            _targetBinaryWriter = new BinaryWriter(File.OpenWrite(targetData.Saf.Path));

            // Patch files
            foreach (var patchData in patchDataList)
            {
                // Create binary reader instance to read the patch data
                _patchBinaryReader = new BinaryReader(File.OpenRead(patchData.Saf.Path));

                // Patch files
                PatchFiles(targetData, patchData);

                // Cleanup
                _patchBinaryReader.Dispose();
                _patchBinaryReader = null;
            }

            // Remove previous sah and save the new one
            FileHelper.DeleteFile(targetData.Sah.Path);
            targetData.Sah.Write(targetData.Sah.Path);
        }
        finally
        {
            // Cleanup
            _targetBinaryWriter?.Dispose();
            _targetBinaryWriter = null;
            _patchBinaryReader?.Dispose();
            _patchBinaryReader = null;
        }
    }

    /// <summary>
    /// Adds all the files from a patch data file into another data file
    /// </summary>
    /// <param name="targetData">Data where to save the files</param>
    /// <param name="patchData">Data where to take the files from</param>
    private static void PatchFiles(Data targetData, Data patchData)
    {
        foreach (var patchFile in patchData.FileIndex.Values)
            // File was already present in the data - it needs to be replaced and doesn't need to be added to the FileIndex
            if (targetData.FileIndex.TryGetValue(patchFile.RelativePath, out var targetFile))
            {
                // Clear previous file's bytes
                ClearBytes(targetFile.Offset, targetFile.Length);

                // Check if patch file fits in the previous file's location
                // If it doesn't, it needs to be added at the end of the file
                if (patchFile.Length > targetFile.Length)
                {
                    var newOffset = AppendFile(patchFile);

                    // Replace the previous file's metadata
                    targetFile.Offset = newOffset;
                    targetFile.Length = patchFile.Length;
                }
                // If it fits, the previous file location is used
                else
                {
                    WriteFile(targetFile.Offset, patchFile);

                    // Replace the previous file's length - offset stays the same
                    targetFile.Length = patchFile.Length;
                }
            }
            // File wasn't part of the data - it will be added at the end of the file and it must be added to the FileIndex
            else
            {
                var offset = AppendFile(patchFile);

                // Set offset from targetData
                patchFile.Offset = offset;

                // Add patchFile to the targetData's Sah
                var folder = targetData.Sah.EnsureFolderExists(patchFile.ParentFolder.RelativePath);
                folder.AddFile(patchFile);

                // Increase data file count
                targetData.FileCount++;

                // Add file to file index
                targetData.FileIndex.Add(patchFile.RelativePath, patchFile);
            }
    }

    /// <summary>
    /// Sets the target saf's bytes to '\0'
    /// </summary>
    /// <param name="offset">Saf offset where to begin</param>
    /// <param name="length">Amount of bytes to set to 0</param>
    private static void ClearBytes(long offset, int length)
    {
        // Set writing offset
        _targetBinaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);

        // Write empty data
        var emptyData = new byte[length];
        _targetBinaryWriter.Write(emptyData);
    }

    /// <summary>
    /// Writes a file into the target Saf file from a patch Saf file
    /// </summary>
    /// <param name="targetOffset">The target saf's offset where to write the patch file</param>
    /// <param name="patchFile">Patch file instance</param>
    private static long WriteFile(long targetOffset, SFile patchFile)
    {
        // Set reading offset
        _patchBinaryReader.BaseStream.Seek(patchFile.Offset, SeekOrigin.Begin);

        // Read patch buffer
        var patchBuffer = _patchBinaryReader.ReadBytes(patchFile.Length);

        // Write patch into target Saf
        _targetBinaryWriter.BaseStream.Seek(targetOffset, SeekOrigin.Begin);
        _targetBinaryWriter.Write(patchBuffer);

        return targetOffset;
    }

    /// <summary>
    /// Appends a file at the end of the target Saf file from a patch Saf file
    /// </summary>
    /// <param name="patchFile">Patch file instance</param>
    private static long AppendFile(SFile patchFile) => WriteFile(_targetBinaryWriter.BaseStream.Length, patchFile);
}
