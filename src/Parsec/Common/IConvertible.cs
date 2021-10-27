namespace Parsec.Common
{
    public interface IConvertible<TObject1, TObject2>
    {
        TObject1 Convert(TObject2 obj);
        TObject2 Convert(TObject1 obj);
    }
}
