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
            kp.Listele();
            musteripopodata.ItemsSource = kp.Listele();
            kp.Listele1();
            aracpopodata.ItemsSource = kp.Listele1();




        }

        
        Class1 kp=new Class1(); 
        private void musteribtn_Click(object sender, RoutedEventArgs e)
        {
            musteripopupxaml musteri = new musteripopupxaml();
            musteri.Show();

            

        }

        private void aracbtn_Click(object sender, RoutedEventArgs e)
        {
            //datagrid.ItemsSource = kp.Listele1();

            Window2 sa = new Window2();
            sa.Show();

        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

        }

        private void aracpopodata_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var asa = (aracclass)aracpopodata.SelectedItem as aracclass;
            markatxt.Text = asa.Marke;
            modeltxt.Text = asa.Model;
            yakıt_txt.Text = asa.Kraftstoff;
            plakatxt.Text = asa.Nummernschild;
            vitestxt.Text = asa.Getriebetype;
            kasatxt.Text = asa.Karosserientyp;



        }

        private void musteripopodata_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var sas = (mustericlass)musteripopodata.SelectedItem as mustericlass;

            adtxt.Text = sas.Ad;
            soyadtxt.Text = sas.Soyad;
            tctxt.Text = sas.Tcnummer;
            teltxt.Text = sas.Telefonu;
            mailtxt.Text = sas.Mail;
            ehlinotxt.Text = sas.Ehliyetno.ToString();
        }
    }
}
