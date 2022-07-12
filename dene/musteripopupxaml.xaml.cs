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
    /// musteripopupxaml.xaml etkileşim mantığı
    /// </summary>
    public partial class musteripopupxaml : Window
    {
        Class1 kp= new Class1();
        Kira sa= new Kira();  
        public musteripopupxaml()
        {
            InitializeComponent();
            kp.Listele();
            musteripopodata.ItemsSource = kp.Listele();
        }

        private void musteripopodata_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            Kira swww = new Kira();
            swww.Close();
            Kira swww1 = new Kira();

            swww1.Show();
        }
    }
}
