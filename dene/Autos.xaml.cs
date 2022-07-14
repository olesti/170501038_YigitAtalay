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
using MySqlConnector;
using System.Data;
using System.Windows.Documents;
using System.Windows.Documents.Serialization;
using Syncfusion.SfDataGrid;
using System.Text.RegularExpressions;
//using System.Windows.Xps;
//using System.Windows.Xps.Packaging;


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
        bool xy;

        private bool sa(aracclass asaa)
        {
            MySqlConnection con = new MySqlConnection("Server=localhost;Database=users;Uid=root;Pwd='atalay528';AllowUserVariables=True;UseCompression=True;");

            MySqlDataAdapter baglayici = new MySqlDataAdapter();
            MySqlCommand komut = new MySqlCommand("Select * from testdb.arac where plaka = '" + plakatxt.Text + "'", con);
            con.Open();
            MySqlDataReader reader = komut.ExecuteReader();

            if (reader.Read())
            {
                xy = false;

            }
            else
            {
                xy = true;


            }

            return xy;
        }
        bool yz=true;
        private bool txttt()
        {
            if (markatxt.Text=="" || modeltxt.Text == ""
                || plakatxt.Text == "" || altertxt.Text == "" || yakıtlist.Text == ""
                || kasalist.Text == "" )
            {
                yz=false;
            }
            else
            {
                yz = true;
            }
            return yz;

        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            txttt();
            aracclass yeniarac = new aracclass();
            sa(yeniarac);
            
            if (yz)
            {

                if (altertxt.Text.Length == 4 && (plakatxt.Text.Length<8 && plakatxt.Text.Length>6 ))
                { 
                    if (xy)
                    {
                        kp.Ekle(yeniarac);
                        aracdata.ItemsSource = kp.Listele1();

                        kp.Listele();
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Sie können denselben Auto nicht erneut hinzufügen.");

                    }
                }
                else
                {
                    MessageBox.Show("Alter 4 haneli olmalı \nGirilen Plakayı kontrol edin");

                }
            }
            else
            {
                MessageBox.Show("Sie müssen jedes Feld ausfüllen");
            }
            

        }
        private void musteridata_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (aracdata.SelectedItem != null)
            {
                aracclass selectedEmployee = aracdata.SelectedItem as aracclass;
                int i = 0;
                int j = 0;
                int z = 0;
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
                if (selectedEmployee.Kraftstoff == "Diesel")
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
                motorgüctxt.Text = selectedEmployee.Farbe;
                schade.SelectedIndex = j;
                yakıtlist.SelectedIndex = z;
                kostentxt.Text = selectedEmployee.Kosten.Substring(0, selectedEmployee.Kosten.Length - 1); ;
            }
           
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
            yenikisi.Kraftstoff = yakıtlist.Text;
            yenikisi.Getriebetype = şanzımantxt.Text;
            yenikisi.Km = kmtxt.Text;
            yenikisi.Karosserientyp = kasalist.Text;
            yenikisi.Schaden = schade.Text;
            yenikisi.Farbe = motorgüctxt.Text;
            yenikisi.Kosten = kostentxt.Text;
            if (yz)
            {

                if (altertxt.Text.Length == 4 && (plakatxt.Text.Length < 8 && plakatxt.Text.Length > 6))
                {
                    if (xy)
                    {
                        kp.Guncelle(esarac, yenikisi);
                        aracdata.ItemsSource = kp.Listele1();
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Sie können denselben Auto nicht erneut hinzufügen.");

                    }
                }
                else
                {
                    MessageBox.Show("Alter 4 haneli olmalı \nGirilen Plakayı kontrol edin");

                }
            }
            else
            {
                MessageBox.Show("Sie müssen jedes Feld ausfüllen");
            }

            


        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            /*
            PrintDialog printDlg = new PrintDialog();

            printDlg.PrintVisual(aracdata, "AutoList");
            */
            musteripopupxaml musteripopupxaml  = new musteripopupxaml();
            musteripopupxaml.Show();
            musteripopupxaml.Close();

        }

        private void kostentxt_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void PreviewTextInput1(object sender, TextCompositionEventArgs e)
        {

        }

 
    }
}
