namespace TagsCloud.Abstract
{
    // CR (krait): Название этого интерфейса не делает понятным его назначение.
    public interface IDataExtractor
    {
        string GetRawText(string filename);
    }
}