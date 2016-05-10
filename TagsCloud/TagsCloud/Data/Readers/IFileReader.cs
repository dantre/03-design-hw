namespace TagsCloud.Data.Readers
{
    public interface IFileReader
    {
        string GetRawText(string filename);
    }
}