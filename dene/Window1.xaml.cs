using MySql.Data.MySqlClient;
using System;
using System.Net.Mail;
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
using System.Net.Http;

namespace GetLos_App
{
    /// <summary>
    /// Window1.xaml etkileşim mantığı
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        private bool Saaae(string sadff)
        {
            if (sadff.Length < 8 || sadff.Length > 14)
            {
                return false;

            }
            else if (!sadff.Any(char.IsUpper))
            {
                return false;

            }
            else if (!sadff.Any(char.IsLower))
            {
                return false;

            }
            else if(sadff.Contains(" "))
            {
                return false;

            }
            else
            {
                return true;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (aktiviertxt.Text == global)
            {
                passss.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Der eingegebene Aktivierungscode ist falsch");
            }

        }
        string global= null;
        string email= null;
        string id= null;
        MailMessage eposta=new MailMessage();
        private void sendmailbtn_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection con = new MySqlConnection("Server=localhost;Database=users;Uid=root;Pwd='atalay528';AllowUserVariables=True;UseCompression=True;");

            MySqlDataAdapter baglayici = new MySqlDataAdapter();
            MySqlCommand komut = new MySqlCommand("Select * from users where email like '%" + usertxt.Text + "%'", con);
            con.Open();
            MySqlDataReader reader = komut.ExecuteReader();
            if (reader.Read())
            {
                
                eposta.From = new MailAddress("ataly08@hotmail.com");
                email=reader[3].ToString();
                id=reader[0].ToString();
                eposta.To.Add(reader[3].ToString());
                eposta.Subject = "Şifre Hatırlatma";
                global = sa(20);
                eposta.Body = global;
                SmtpClient sas = new SmtpClient();
                sas.Credentials = new System.Net.NetworkCredential("e170501038@stud.tau.edu.tr", "atalay528");
                sas.Host = "smtp.gmail.com";
                sas.EnableSsl = true;
                sas.Port = 587;
                
                sas.Send(eposta);
                MessageBox.Show("Aktivierungscode an" + reader[3].ToString()+ "​​E-Mail-Adresse gesendet.");



            }
            else
            {
                MessageBox.Show("Datenbankfehler");
            }

        }
        private string sa(int codeLength)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            System.Random objRandom = new System.Random();

            string[] strChars = { "A","B","C","D","E","F","G","H","I",

                            "J","K","L","M","N","O","P","Q","R",

                            "S","T","U","V","W","X","Y","Z",

                            "1","2","3","4","5","6","7","8","9","0",

                            "a","b","c","d","e","f","g","h","i","j","k",

                            "l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"};

            int maxRand = strChars.GetUpperBound(0);

            for (int i = 0; i< codeLength; i++)
            {
                int rndNumber = objRandom.Next(maxRand);

                sb.Append(strChars[rndNumber]);
            }

            return sb.ToString();
        }

        private void aktiviertxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void passbtn_Click(object sender, RoutedEventArgs e)
        {
            if (passwordtxt.Text == passwordtxt2.Text)
            {
                if (Saaae(passwordtxt.Text))
                {

                    MySqlConnection con = new MySqlConnection("Server=localhost;Database=users;Uid=root;Pwd='atalay528';AllowUserVariables=True;UseCompression=True;");

                    try
                    {

                        MySqlDataAdapter baglayici = new MySqlDataAdapter();
                        MySqlCommand komut = new MySqlCommand("update userslast set password= '" + passwordtxt.Text + "' where idusers=" + id, con);
                        con.Open();
                        komut.ExecuteNonQuery();
                        MessageBox.Show("Das Passwort wurde erfolgreich geändert.");
                    }
                    finally
                    {
                        if (con != null)
                            con.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Das Passwort muss einen Großbuchstaben, einen Kleinbuchstaben und eine Zahl enthalten.");
                }
;
            }
            else
            {
                MessageBox.Show("Passwörter sind nicht gleich");
            }
        }

        private void passwordtxt_MouseEnter(object sender, MouseEventArgs e)
        {
            
        }

        private void passwordtxt_ToolTipOpening(object sender, ToolTipEventArgs e)
        {
            passwordtxt.ToolTip = "Das Passwort muss einen Großbuchstaben, einen Kleinbuchstaben, eine Zahl und ein Symbol enthalten.";


        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            bool K = Keyboard.IsKeyDown(Key.K);
            bool shift = Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift);
            if (K && shift) 
            {
                if (passss.IsEnabled == true)
                {
                    passss.IsEnabled = false;

                }
                else
                {
                    passss.IsEnabled = true;

                }

            }
            

        }
    }
}
