using TagsCloud.Abstract;

namespace Tests.NInject
{
    class FakeReader : IFileReader
    {
        public string GetRawText(string filename)
        {
            return "A, A!A.B B C";
        }
    }
}
