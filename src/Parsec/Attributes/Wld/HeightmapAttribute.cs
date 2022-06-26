namespace Parsec.Attributes.Wld;

public class HeightmapAttribute : UsePropertyAttribute
{
    public HeightmapAttribute(string propertyName) : base(propertyName)
    {
    }

    public int CalculateLengthFromMapSize(int mapSize) => (int)Math.Pow(mapSize / 2 + 1, 2) * 2;
}
