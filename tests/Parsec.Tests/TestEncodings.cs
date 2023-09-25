using System.Text;

namespace Parsec.Tests;

public static class TestEncodings
{
    public static readonly Encoding Encoding1252 = CodePagesEncodingProvider.Instance.GetEncoding(1252);
}
