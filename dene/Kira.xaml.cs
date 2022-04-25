using System;
using System.Collections.Generic;
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
    public partial class Kira : Window
    {
        public Kira()
        {
            InitializeComponent();
        }

        
        public class Kiralama
        {
            public string Vorname { get; set; }
            public string Nachname { get; set; }
            public int Telefonnumer { get; set; }
            public int Tcnummer { get; set; }
            public string Email { get; set; }
            public string Ehliyetno { get; set; }
            public string Plaka { get; set; }
            public string Model { get; set; }
            public string Marka { get; set; }
            public string Autoage { get; set; }
            public string Yakıt { get; }
            public string Vites { get; }
            public int Km { get; set; }
            public string Renk { get; set; }
            public string Kasatipi { get; set; }

        }
        Class1 kp=new Class1(); 
        private void musteribtn_Click(object sender, RoutedEventArgs e)
        {
            datagrid.ItemsSource = kp.Listele(); 
        }

        private void aracbtn_Click(object sender, RoutedEventArgs e)
        {
            datagrid.ItemsSource = kp.Listele1();

        }
    }
}
