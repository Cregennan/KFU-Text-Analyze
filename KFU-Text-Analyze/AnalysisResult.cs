using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFU_Text_Analyze
{
    public class AnalysisResult
    {
        public int TotalWordsCount = 0;
        public String InputText = "";
        public int UniqueWordsCount = 0;
        public string TenLongestWords = "";
        public string TenFamousWords = "";
        public SortedDictionary<char, double> RussianLetterStatistics = new SortedDictionary<char, double>();
        public SortedDictionary<char, double> EnglishLetterStatistics = new SortedDictionary<char, double>();
    }
}
