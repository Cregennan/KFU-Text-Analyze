using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KFU_Text_Analyze
{
    public class TextAnalyzer
    {
       public TextAnalyzer(String text = "")
        {
            Text = text;
        }
        public String Text { get; set; }

        public AnalysisResult Analyze()
        {
            AnalysisResult a = new AnalysisResult();
            a.InputText = Text;

            //Нормализация текста (Удаление мусора)
            Text = Regex.Replace(Text, @"[^a-zA-ZА-Яа-я ]+", "");
            Text = Text.Replace(Environment.NewLine, " ");


            //Массив слов   
            List<String> Words = new List<String>(Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

            //Нормализованные слова
            List<String> Normalized = new List<String>();
            foreach(String w in Words)
            {
                Normalized.Add(w.ToLower());
            }
            Normalized.Sort((x, y) => x.Length.CompareTo(y.Length));
            List<String> NormalizedDesc = Normalized;
            NormalizedDesc.Reverse();


            //Нормализованная куча уникальных слов
            HashSet<String> NormalizedSet = new HashSet<string>();
            foreach(String w in NormalizedDesc)
            {
                NormalizedSet.Add(w);
            }


            //Количество слов
            a.TotalWordsCount = Words.Count();
            //Количество уникальных слов
            a.UniqueWordsCount = NormalizedSet.Count();


            //10 самых длинных слов
            int i = 0;
            foreach(String w in NormalizedSet)
            {
                if (i > 9) break;
                a.TenLongestWords += w + ", ";
                i++;
            }
            a.TenLongestWords = a.TenLongestWords.Remove(a.TenLongestWords.Length - 2);


            //10 самых частых слов
            Dictionary<String, int> dict = new Dictionary<string, int>();
            foreach(String w in Normalized)
            {
                if (!dict.ContainsKey(w))
                {
                    dict.Add(w, 0);
                }
                dict[w]++;
            }
            var sortedDict = from entry in dict orderby entry.Value descending select entry;
            int j = 0;
            foreach(KeyValuePair<string, int> kvp in sortedDict)
            {
                if (j > 9) break;
                a.TenFamousWords += kvp.Key + ", ";
                j++;
            }
            a.TenFamousWords = a.TenFamousWords.Remove(a.TenFamousWords.Length - 2);
            

            //Статистика букв в тексте
            Dictionary<char, int> lettersCount = new Dictionary<char, int>();
            int TotalLettersCount = 0;

            foreach(String s in Normalized){
               foreach(char t in s){
                    if (!lettersCount.ContainsKey(t))
                    {
                        lettersCount.Add(t, 1);
                    }
                    else
                    {
                        lettersCount[t]++;
                    }
                    TotalLettersCount++;
               }
            }
            SortedDictionary<char, double> RussianLettersStatistics = new SortedDictionary<char, double>();
            SortedDictionary<char, double> EnglishLettersStatistics = new SortedDictionary<char, double>();
            for (char c = 'a'; c <= 'z'; c++)
            {
                EnglishLettersStatistics.Add(c, 0);
            }
            for (char c = 'а'; c <= 'я'; c++)
            {
                RussianLettersStatistics.Add(c, 0);
            }
            foreach (KeyValuePair<char, int> t in lettersCount)
            {
                if (t.Key >= 'a' && t.Key <= 'z')
                {
                    EnglishLettersStatistics[t.Key] = Math.Round((double)lettersCount[t.Key] / TotalLettersCount * 100);
                }else if (t.Key >= 'а' && t.Key <= 'я')
                {
                    RussianLettersStatistics[t.Key] = Math.Round((double)lettersCount[t.Key] / TotalLettersCount * 100);
                }
            }
            a.EnglishLetterStatistics = EnglishLettersStatistics;
            a.RussianLetterStatistics = RussianLettersStatistics;




            return a;
        }
    }
}
