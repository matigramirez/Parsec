using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Alt;

/// <summary>
/// Class that represents an animation record in an ALT file.
/// Throughout the list of animations, there's some of them which have 0-length names, when this happens, the rest of the fields are not present
/// in the file, so they need to be skipped when reading or writing.
/// </summary>
public sealed class AltAnimation : ISerializable
{
    /// <summary>
    /// Animation (ANI) file name for this slot. The slot index is the action id the client uses.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Playback mode. The game client only reads the lowest byte (game.exe: <c>movzx eax, byte ptr [anim+0x10]</c>),
    /// the upper three bytes are leftover memory written by the original tooling and are ignored,
    /// so they are kept as-is to preserve byte-exact round trips.
    /// When the clock passes the last frame: <c>1</c> = loop (restart), <c>2</c> = play once and then blend into
    /// the slot given by <see cref="Unknown"/>, <c>0</c> = hold the last frame (used by the death animation).
    /// </summary>
    public int Mode { get; set; }

    /// <summary>
    /// Slot to switch to after a <see cref="Mode"/> <c>2</c> animation ends (<c>0</c> = slot 0, the idle animation).
    /// For example an attack points to the weapon's "ready" slot.
    /// </summary>
    public int Unknown { get; set; }

    /// <summary>
    /// Not read by the client (checked in the EP4.5 and EP5 game.exe), probably a leftover from an older engine version.
    /// </summary>
    public float Float1 { get; set; }

    /// <summary>
    /// Not read by the client, see <see cref="Float1"/>.
    /// </summary>
    public float Float2 { get; set; }

    /// <summary>
    /// Frame (30 frames per second) of the first hit. When the animation clock crosses it, the client spawns the
    /// hit effect and sound and applies the pending damage. <c>0</c> = no hit event.
    /// </summary>
    public float Float3 { get; set; }

    /// <summary>
    /// Frame of the second hit for double-hit attacks (<c>0</c> = none). When set, the first hit only applies
    /// half of the pending damage and this one applies the rest.
    /// </summary>
    public float Float4 { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        Name = binaryReader.ReadString();

        // When name is empty, the rest of the fields are not read
        if (string.IsNullOrEmpty(Name))
            return;

        Mode = binaryReader.ReadInt32();
        Unknown = binaryReader.ReadInt32();
        Float1 = binaryReader.ReadSingle();
        Float2 = binaryReader.ReadSingle();
        Float3 = binaryReader.ReadSingle();
        Float4 = binaryReader.ReadSingle();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        // When name is empty, the rest of the fields are not written and the name length must be set to '0'
        if (string.IsNullOrEmpty(Name))
        {
            binaryWriter.Write(0);
            return;
        }

        binaryWriter.Write(Name);
        binaryWriter.Write(Mode);
        binaryWriter.Write(Unknown);
        binaryWriter.Write(Float1);
        binaryWriter.Write(Float2);
        binaryWriter.Write(Float3);
        binaryWriter.Write(Float4);
    }
}
