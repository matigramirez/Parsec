namespace Parsec.Attributes.Wld;

public class TextureMapAttribute : UsePropertyAttribute
{
    public TextureMapAttribute(string propertyName) : base(propertyName)
    {
    }

    public int CalculateLengthFromMapSize(int mapSize) => (int)Math.Pow(mapSize / 2 + 1, 2);
}
