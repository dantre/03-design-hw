using System;
using System.Collections.Generic;

namespace TagsCloud.Abstract
{
    // CR (krait): �������� ����� ���������� �� ������ �������� ��� ����������.
    public interface IDataProcessor
    {
        Tuple<string, int>[] GetWordsFrequencies(IEnumerable<string> words);
    }
}