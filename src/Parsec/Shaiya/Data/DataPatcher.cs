using Parsec.Helpers;

namespace Parsec.Shaiya.Data;

public class DataPatcher : IDisposable
{
    private BinaryReader? _patchBinaryReader;
    private BinaryWriter? _targetBinaryWriter;

    public void Dispose()
    {
        _patchBinaryReader?.Dispose();
        _targetBinaryWriter?.Dispose();
    }

    /// <summary>
    /// Applies the patches in the patch list into a target data
    /// </summary>
    /// <param name="targetData">Data instance where the patch should be applied</param>
    /// <param name="patchData">Data instance containing the patch files</param>
    /// <param name="filePatchedCallback">Action which gets invoked when a file gets patched</param>
    public void Patch(Data targetData, Data patchData, Action? filePatchedCallback = null)
    {
        _targetBinaryWriter = new BinaryWriter(File.OpenWrite(targetData.Saf.Path));
        _patchBinaryReader = new BinaryReader(File.OpenRead(patchData.Saf.Path));

        PatchFiles(targetData, patchData, filePatchedCallback);

        // Delete previous sah and save the new one
        FileHelper.DeleteFile(targetData.Sah.Path);
        targetData.Sah.Write(targetData.Sah.Path);

        Dispose();
    }

    /// <summary>
    /// Adds all the files from a patch data file into another data file
    /// </summary>
    /// <param name="targetData">Data where to save the files</param>
    /// <param name="patchData">Data where to take the files from</param>
    /// <param name="filePatchedCallback">Action which gets invoked when a file gets patched</param>
    private void PatchFiles(Data targetData, Data patchData, Action? filePatchedCallback = null)
    {
        foreach (var patchFile in patchData.FileIndex.Values)
        {
            // File was already present in the data - it needs to be replaced and doesn't need to be added to the FileIndex
            if (targetData.FileIndex.TryGetValue(patchFile.RelativePath, out var targetFile))
            {
                ClearBytes(targetFile.Offset, targetFile.Length);

                // Check if patch file fits in the previous file's location
                // If it doesn't, it needs to be added at the end of the file
                if (patchFile.Length > targetFile.Length)
                {
                    var newOffset = AppendFile(patchFile);
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
                patchFile.Offset = offset;

                var folder = targetData.Sah.EnsureFolderExists(patchFile.ParentDirectory.RelativePath);
                folder.AddFile(patchFile);

                targetData.FileCount++;
                targetData.FileIndex.Add(patchFile.RelativePath, patchFile);
            }

            filePatchedCallback?.Invoke();
        }
    }

    /// <summary>
    /// Sets the target saf's bytes to '\0'
    /// </summary>
    /// <param name="offset">Saf offset where to begin</param>
    /// <param name="length">Amount of bytes to set to 0</param>
    private void ClearBytes(long offset, int length)
    {
        _targetBinaryWriter!.BaseStream.Seek(offset, SeekOrigin.Begin);

        var emptyData = new byte[length];
        _targetBinaryWriter!.Write(emptyData);
    }

    /// <summary>
    /// Writes a file into the target Saf file from a patch Saf file
    /// </summary>
    /// <param name="targetOffset">The target saf's offset where to write the patch file</param>
    /// <param name="patchFile">Patch file instance</param>
    private long WriteFile(long targetOffset, SFile patchFile)
    {
        _patchBinaryReader!.BaseStream.Seek(patchFile.Offset, SeekOrigin.Begin);

        var patchBuffer = _patchBinaryReader.ReadBytes(patchFile.Length);

        _targetBinaryWriter!.BaseStream.Seek(targetOffset, SeekOrigin.Begin);
        _targetBinaryWriter.Write(patchBuffer);

        return targetOffset;
    }

    /// <summary>
    /// Appends a file at the end of the target Saf file from a patch Saf file
    /// </summary>
    /// <param name="patchFile">Patch file instance</param>
    private long AppendFile(SFile patchFile)
    {
        return WriteFile(_targetBinaryWriter!.BaseStream.Length, patchFile);
    }
}
