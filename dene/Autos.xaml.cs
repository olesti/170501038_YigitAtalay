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
using System.Windows.Shapes;

namespace GetLos_App
{
    /// <summary>
    /// Window1.xaml etkileşim mantığı
    /// </summary>
    public partial class Autos : Window
    {

        public Autos()
        {
            InitializeComponent();

        }
        public class Auto
        {
            public string Plaka { get; set; }
            public string Marke { get; set; }
            public int  Alter { get; set; }
            public string Kraftstoff { get; set; }
            public string Nummernschild { get; set; }
            public String Getriebetype { get; set; }
            public int Km { get; set; }
            public String Motorleistung { get; set; }
            public String Traktion { get; set; }
            public String Tür { get; set; }
            public String Karosserientyp { get; set; }
            public String Schaden { get; set; }
            public Image image { get; set; }
            //public Boolean hasar { get; set; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "images files (*.png)|*.png|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == true)
            {
                //Get the path of specified file
                filePath = openFileDialog.FileName;

                //Read the contents of the file into a stream
                var fileStream = openFileDialog.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void musteridata_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
