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

namespace dene
{
    /// <summary>
    /// Window1.xaml etkileşim mantığı
    /// </summary>
    public partial class Musteri : Window
    {
        List<Musteriler> mus = new List<Musteriler>();
        
        public Musteri()
        {
            InitializeComponent();
            musteridata.ItemsSource = mus;
            dogumpicker.DisplayDateEnd = DateTime.Now;
            dogumpicker.DisplayDateStart = new DateTime(1900, 1, 1);
            dogumpicker.Language = this.Language ;
            //dogumpicker.SelectedDateFormat = DatePickerFormat.Long;
        }
        public class Musteriler
        {
            public string Vorname { get; set; }
            public string Nachname { get; set; }
            public DatePicker birhday { get; set; }
            public int Tcnummer { get; set; }
            public int Telefonnummer { get; set; }
            public String Email { get; set; }
            public String Adresse { get; set; }
            public String EhliyetNo { get; set; }
            public String Ehliyettür { get; set; }
            public String Not { get; set; }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mus.Add(new Musteriler() { 
                Vorname = adtxt.Text, 
                Nachname = soyadtxt.Text,
                birhday = dogumpicker,
                Tcnummer = 2,
                Telefonnummer=1 ,
                Email=emailtxt.Text,
                Adresse=adrestxt.Text,
                EhliyetNo=ehliyetnotxt.Text,
                Ehliyettür= ehliyetturtxt.Text,
                Not=notlartxt.Text,
            });
            musteridata.Items.Refresh();

        }
    }
}
