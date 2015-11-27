using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
