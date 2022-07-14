using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GetLos_App
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        public string sa ;

        public MainWindow()
        {
            
            InitializeComponent();
            

        }
       
        private void aracbtn_Click(object sender, RoutedEventArgs e)
        {
            Autos arac = new Autos();
            arac.Show();    
        }

        private void musteribtn_Click(object sender, RoutedEventArgs e)
        {
            if (sa == "1"|| sa == "3")
            {
                Musteri ara = new Musteri();
                ara.Show();
            }
            else
            {
                MessageBox.Show("Sie sind nicht berechtigt, darauf zuzugreifen");
            }
        }

        private void kiralama_Click(object sender, RoutedEventArgs e)
        {
            if (sa == "1" || sa == "2")
            {
                Kira saaa = new Kira();
                saaa.Show();
            }
            else
            {
                MessageBox.Show("Sie sind nicht berechtigt, darauf zuzugreifen");
            }
            

        }

        private void faturabtn_Click(object sender, RoutedEventArgs e)
        {
            if (sa == "1" || sa == "3")
            {
                Window3 saaa = new Window3();
                saaa.Show();
            }
            else
            {
                MessageBox.Show("Sie sind nicht berechtigt, darauf zuzugreifen");
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
