using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace KFU_Text_Analyze
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            //btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }
        public TextAnalyzer analyzer;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.analyzer = new TextAnalyzer();
            analyzer.Text = UserInputField.Text;
            AnalysisResult res = analyzer.Analyze();

            TextAnalyzeResultsWindow textAnalyze = new TextAnalyzeResultsWindow(res);
            textAnalyze.ShowDialog();
            //this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.FileName = "Document";
            dialog.DefaultExt = ".txt";
            dialog.Filter = "Файл с текстом (.txt)|*.txt";

            if ((bool)dialog.ShowDialog())
            {
                UserInputField.Text = File.ReadAllText(dialog.FileName);
            }
        }
    }
}
