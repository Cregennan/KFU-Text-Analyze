using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Controls.DataVisualization.Charting;
namespace KFU_Text_Analyze
{
    /// <summary>
    /// Логика взаимодействия для TextAnalyzeResultsWindow.xaml
    /// </summary>
    public partial class TextAnalyzeResultsWindow
    {
        public TextAnalyzeResultsWindow(AnalysisResult results)
        {
            InitializeComponent();

            UniqueWordsCount.Text = results.UniqueWordsCount.ToString();
            TotalWordsCount.Text = results.TotalWordsCount.ToString();
            TenLongestWords.Text = results.TenLongestWords;
            TenFamousWords.Text = results.TenFamousWords;
            
            ((ColumnSeries)RussianLettersChart.Series[0]).ItemsSource = results.RussianLetterStatistics;
            ((ColumnSeries)EnglishLettersChart.Series[0]).ItemsSource = results.EnglishLetterStatistics;



        }
    }
}
