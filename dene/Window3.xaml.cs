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
using System.Net.Mail;
using System.ComponentModel;



namespace GetLos_App
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        

        public Window3()
        {
            InitializeComponent();
            asas();


            //yakitcombo.ItemsSource = pp;

        }
        public void asas()
        {
            
            //yakitcombo.ItemsSource = typeof(Color).GetProperties();

        }
       
        public bool IsValid(string Email)
        {
            try
            {
                MailAddress m = new MailAddress(Email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        
    }
}
