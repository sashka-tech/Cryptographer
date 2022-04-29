using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using Xceed.Words.NET;

namespace CourseProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.DefaultExt = ".docx";
            dialog.FileName = "Document";
            dialog.Filter = "Text files (*.txt)|*.txt|Document Word (*.docx)|*docx";
            bool? result = dialog.ShowDialog();
            try
            {
                if (result == true)
                {
                    var value = dialog.FilterIndex;
                    string fileName = dialog.FileName;
                    if (value == 1)
                    {
                        string txt = File.ReadAllText(fileName);
                        sourceTB.Text = txt;
                    }
                    else if (value == 2)
                    {
                        var doc = DocX.Load(fileName);
                        string contents = doc.Text;
                        sourceTB.Text = contents;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to open file.", "Error");
            }
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (sourceTB.Text == "")
            {
                MessageBox.Show("Write or open text...", "Error");
            }
            if (resultTB.Text == "")
            {
                MessageBox.Show("Please decrypt or encrypt some text...", "Error");
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = "Document";
                saveFileDialog.Filter = "Text file (*.txt)|*.txt|Document Word (*.docx)|*.docx";
                bool? result = saveFileDialog.ShowDialog();
                try
                {
                    if (result == true)
                    {
                        string fileName = saveFileDialog.FileName;
                        var value = saveFileDialog.FilterIndex;
                        if (value == 1)
                        {
                            File.WriteAllText(fileName, resultTB.Text);
                        }
                        else if (value == 2)
                        {
                            var doc = DocX.Create(fileName, Xceed.Document.NET.DocumentTypes.Document);
                            doc.InsertParagraph(resultTB.Text);
                            doc.Save();
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Failed to save file...", "Error");
                }
            }
        }
        private void encrypt_Click(object sender, RoutedEventArgs e)
        {
            if (sourceTB.Text == "" && keyTB.Text == "")
            {
                resultTB.Text = "";
            }
            else if (sourceTB.Text == "")
            {
                resultTB.Text = "";
            }
            else if (keyTB.Text == "")
            {
                keyTB.Text = "Your key...";
            }
            else
            {
                resultTB.Text = Vigenere.Encrypt(sourceTB.Text, keyTB.Text.ToLower());
            }
        }

        private void decrypt_Click(object sender, RoutedEventArgs e)
        {
            if (sourceTB.Text == "" || keyTB.Text == "")
            {
                resultTB.Text = "";
            }
            else if (keyTB.Text == "")
            {
                MessageBox.Show("Key missing...", "Error");
                keyTB.Text = "Your key...";
            }
            else
            {
                resultTB.Text = Vigenere.Decrypt(sourceTB.Text, keyTB.Text);
            }
        }

        private void sourceTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sourceTB.Text == "")
            {
                sourceTB.Text = "Your text...";
            }
        }

        private void resultTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (resultTB.Text == "")
            {
                resultTB.Text = "Encrypted/decrypted text...";
            }
        }
    }
}
