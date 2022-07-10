using iTextSharp.text;
using iTextSharp.text.pdf;
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
using Syncfusion.UI.Xaml.Grid.Converter;
using Syncfusion.Windows.Shared;
using System.Diagnostics;
namespace GetLos_App
{
    /// <summary>
    /// Window1.xaml etkileşim mantığı
    /// </summary>
    public partial class Autos : Window
    {
        Class1 kp = new Class1();
        public Autos()
        {
            InitializeComponent();
            kp.Listele1();
            aracdata.ItemsSource = kp.Listele1();

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
            aracclass yeniarac = new aracclass();

           
            yeniarac.Marke = markatxt.Text;
            yeniarac.Model = modeltxt.Text;
            yeniarac.Nummernschild = plakatxt.Text;
            yeniarac.Alter = Convert.ToInt32(altertxt.Text);
            yeniarac.Kraftstoff = "sss";
            yeniarac.Getriebetype = şanzımantxt.Text;
            yeniarac.Km = kmtxt.Text;
            yeniarac.Karosserientyp= "asas";
            yeniarac.Schaden = schade.SelectedIndex.ToString();

            kp.Ekle(yeniarac);
            kp.Listele();
        }
        private void musteridata_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            aracclass selectedEmployee = aracdata.SelectedItem as aracclass;
            int i=0;
            int j=0;
            int z=0;
            if (selectedEmployee.Karosserientyp == "Hatchback")
            {
                i = 0;
            }
            if (selectedEmployee.Karosserientyp == "Sedan")
            {
                i = 1;

            }
            if (selectedEmployee.Karosserientyp == "Stationwagon")
            {
                i = 2;

            }
            if (selectedEmployee.Schaden == "0")
            {
                j = 0;
            }
            if (selectedEmployee.Schaden == "1")
            {

                j = 1;

            }
            if (selectedEmployee.Kraftstoff == "Benzin")
            {

                z = 0;

            }
            if (selectedEmployee.Kraftstoff == "Dizel")
            {

                z = 1;

            }
            if (selectedEmployee.Kraftstoff == "Elektrik")
            {

                z = 2;

            }
            if (selectedEmployee.Kraftstoff == "Lpg")
            {

                z = 3;

            }

            markatxt.Text = selectedEmployee.Marke;
            modeltxt.Text = selectedEmployee.Model;
            kmtxt.Text = selectedEmployee.Km;
            kasalist.SelectedIndex = i;

            şanzımantxt.Text = selectedEmployee.Getriebetype;
            plakatxt.Text = selectedEmployee.Nummernschild;
            altertxt.Text = selectedEmployee.Alter.ToString();
            schade.SelectedIndex = j;
            yakıtlist.SelectedIndex = z;
        }
        private void benzin_Selected(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            aracclass aracclass2 = new aracclass();
            aracclass2 = (aracclass)aracdata.SelectedItem as aracclass;
            kp.Sil(aracclass2);
            aracdata.ItemsSource = kp.Listele1();

        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            aracclass esarac = new aracclass();
            esarac = (aracclass)aracdata.SelectedItem as aracclass;
            aracclass yenikisi = new aracclass();


            yenikisi.Marke = markatxt.Text;
            yenikisi.Model = modeltxt.Text;
            yenikisi.Nummernschild = plakatxt.Text;
            yenikisi.Alter = Convert.ToInt32(altertxt.Text);
            yenikisi.Kraftstoff = "sss";
            yenikisi.Getriebetype = şanzımantxt.Text;
            yenikisi.Km = kmtxt.Text;
            yenikisi.Karosserientyp = "asas";
            yenikisi.Schaden = schade.SelectedIndex.ToString();
            kp.Guncelle(esarac, yenikisi);
            aracdata.ItemsSource = kp.Listele1();


        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {


            
        }
    }
}
