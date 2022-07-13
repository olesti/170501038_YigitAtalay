using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySqlConnector;

namespace GetLos_App
{
   
    /// <summary>
    /// Window1.xaml etkileşim mantığı
    /// </summary>
    public partial class Musteri : Window
    {
        /*
        List<Musteriler> mus = new List<Musteriler>();
        OleDbDataReader dr;
        OleDbCommand cmd = new OleDbCommand();
        OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/ataly/Documents/Database2.accdb");
        */
        Class1 kp = new Class1();

        public Musteri()
        {
            

            InitializeComponent();
            kp.Listele();
            //OleDbConnection cmd1 = new  OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database2.accdb");
            /*cn.Open();
            var sasa = "select * from musteri";
            OleDbCommand cmd = new OleDbCommand(sasa, cn);

            dr = cmd.ExecuteReader();
            //musteridata.ItemsSource = mus;
            dogumpicker.DisplayDateEnd = DateTime.Now;
            dogumpicker.DisplayDateStart = new DateTime(1900, 1, 1);
            dogumpicker.Language = this.Language ;
            //dogumpicker.SelectedDateFormat = DatePickerFormat.Long;
            /*cmd1.Open();
            OleDbCommand cmd2 = new OleDbCommand("Select * From musteri");
            */
            musteridata.ItemsSource = kp.Listele();
            

        }
        public MySqlConnection mysqlbaglan = new MySqlConnection("Server=localhost;Database=testdb;Uid=root;Pwd='atalay528';AllowUserVariables=True;UseCompression=True;");
        /*
        void Listele() //Datagrid listeleme işlemi için metot. 
        {

            MySqlDataAdapter baglayici = new MySqlDataAdapter();
            MySqlCommand komut = new MySqlCommand("Select * from musteri", mysqlbaglan);
            mysqlbaglan.Open(); //oluşturtuğumuz tanımı çalıştırarak açılmasını sağlıyoruz


            DataSet tablo = new DataSet();

            komut.Connection = mysqlbaglan;

            baglayici.SelectCommand = komut;
            DataTable dt = new DataTable();
            dt.Load(komut.ExecuteReader());
            mysqlbaglan.Close();

            musteridata.DataContext = dt;


        }*/

        bool xy;

        private bool sa(mustericlass asaa)
        {
            MySqlConnection con = new MySqlConnection("Server=localhost;Database=users;Uid=root;Pwd='atalay528';AllowUserVariables=True;UseCompression=True;");

            MySqlDataAdapter baglayici = new MySqlDataAdapter();
            MySqlCommand komut = new MySqlCommand("Select * from testdb.musteri where mus_tc = '" + tcnummertxt.Text + "' OR mus_ehlino = '" + ehliyetnotxt.Text + "'", con);
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
        bool yz = true;
        private bool txttt()
        {
            if (adtxt.Text == "" || soyadtxt.Text == ""
                || tcnummertxt.Text == "" || telefonnummertxt.Text == "" || ehliyetnotxt.Text == ""
                || emailtxt.Text == "")
            {
                yz = false;
            }
            else
            {
                yz = true;
            }
            return yz;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                mustericlass yenimus = new mustericlass();
                txttt();
                if (yz)
                {
                    yenimus.Ad = adtxt.Text;
                    yenimus.Soyad = soyadtxt.Text;
                    yenimus.Tcnummer = tcnummertxt.Text;
                    yenimus.Telefonu = telefonnummertxt.Text;
                    yenimus.Mail = emailtxt.Text;
                    yenimus.Adresse = adrestxt.Text;
                    yenimus.Ehliyetno = Convert.ToInt32(ehliyetnotxt.Text);
                    yenimus.Ehliyett = ehliyetturtxt.Text;
                    sa(yenimus);
                    if (xy)
                    {


                        kp.Ekle1(yenimus);
                        kp.Listele();
                        musteridata.ItemsSource = kp.Listele();
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Sie können denselben Kunden nicht erneut hinzufügen.");
                    }
                }
                else
                {
                    MessageBox.Show("Sie müssen jedes Feld ausfüllen");
                }
               
               
            }
            catch (Exception ex)
            {

                System.Windows.MessageBox.Show(ex.ToString());
            }
            PrintDialog printDlg = new PrintDialog();
            



            

        }
        private void musteridata_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mustericlass selectedEmployee = musteridata.SelectedItem as mustericlass;

            if (musteridata.SelectedItem != null)
            {
                adtxt.Text = selectedEmployee.Ad;
                soyadtxt.Text = selectedEmployee.Soyad;
                adrestxt.Text = selectedEmployee.Adresse;
                ehliyetnotxt.Text = selectedEmployee.Ehliyetno.ToString();
                ehliyetturtxt.Text = selectedEmployee.Ehliyett;
                emailtxt.Text = selectedEmployee.Mail;
                tcnummertxt.Text = selectedEmployee.Tcnummer;
                telefonnummertxt.Text = selectedEmployee.Telefonu;
            }
            
            
            
            
            //resim.Source = selectedEmployee.image;
            //DataGrid dg = (DataGrid)sender;
            //DataRowView row_select= dg.SelectedItem as DataRowView;
            if (musteridata != null)
            {
                /*
                adtxt.Text = musteridata.SelectedItems[0].ToString();
                soyadtxt.Text = musteridata.SelectedItems[1].ToString();
                adrestxt.Text = musteridata.SelectedItems[2].ToString();
                ehliyetnotxt.Text = musteridata.SelectedItems[3].ToString();
                ehliyetturtxt.Text = musteridata.SelectedItems[4].ToString();
                emailtxt.Text = musteridata.SelectedItems[5].ToString();
                dogumpicker.Text = musteridata.SelectedItems[6].ToString();
                tcnummertxt.Text = musteridata.SelectedItems[7].ToString();
                telefonnummertxt.Text = musteridata.SelectedItems[8].ToString();*/
            }


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            mustericlass aracclass2 = new mustericlass();
            aracclass2 = (mustericlass)musteridata.SelectedItem as mustericlass;
            kp.Sil1(aracclass2);
            adtxt.Text = null;
            soyadtxt.Text = null;
            adrestxt.Text = null;
            ehliyetnotxt.Text = null;
            ehliyetturtxt.Text = null;
            emailtxt.Text = null;
            tcnummertxt.Text = null;
            telefonnummertxt.Text = null;
            kp.Listele();
            musteridata.ItemsSource = kp.Listele();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            txttt();

            mustericlass esarac = new mustericlass();
            esarac = (mustericlass)musteridata.SelectedItem as mustericlass;
            mustericlass yenikisi = new mustericlass();
            if (yz)
            {
                yenikisi.No = esarac.No;
                yenikisi.Ad = adtxt.Text;
                yenikisi.Soyad = soyadtxt.Text;
                yenikisi.Adresse = adrestxt.Text;
                yenikisi.Telefonu = telefonnummertxt.Text;
                yenikisi.Ehliyett = ehliyetturtxt.Text;
                yenikisi.Ehliyetno = Convert.ToInt32(ehliyetnotxt.Text);
                yenikisi.Mail = emailtxt.Text;
                yenikisi.Tcnummer = tcnummertxt.Text;
                kp.Guncelle1(yenikisi);
                musteridata.ItemsSource = kp.Listele();
                
            }
            else
            {
                MessageBox.Show("Sie müssen jedes Feld ausfüllen");
            }


        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();

            printDlg.PrintVisual(musteridata, "KundenList");
        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
