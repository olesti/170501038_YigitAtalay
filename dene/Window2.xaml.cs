﻿using MySql.Data.MySqlClient;
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
    /// Window2.xaml etkileşim mantığı
    /// </summary>
    public partial class Window2 : Window
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        public Window2()
        {
            InitializeComponent();


        }

        private void loginbutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                /*
                MySqlDataAdapter baglayici = new MySqlDataAdapter();
                MySqlCommand komut = new MySqlCommand("Select * from users", mysqlbaglan);
                mysqlbaglan.Open();
                string user = usernametxt.Text;
                string pass = passwordtxt.Text;

                komut.Connection = mysqlbaglan;

                baglayici.SelectCommand = komut;*/
                MySqlConnection con = new MySqlConnection("Server=localhost;Database=users;Uid=root;Pwd='atalay528';AllowUserVariables=True;UseCompression=True;");

                MySqlDataAdapter baglayici = new MySqlDataAdapter();
                MySqlCommand komut = new MySqlCommand("Select * from users where username = '" + usernametxt.Text + "' AND password = '" + passwordtxt.Text + "'", con);
                con.Open();
                MySqlDataReader reader = komut.ExecuteReader();

                if (reader.Read())
                {
                    MainWindow sa =new MainWindow();
                    sa.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Username And Password Not Match!", "VINSMOKE MJ", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            
        }

        private void loginbutton_Copy_Click(object sender, RoutedEventArgs e)
        {
            Window1 sa = new Window1();
            sa.Show();
        }
    }
}