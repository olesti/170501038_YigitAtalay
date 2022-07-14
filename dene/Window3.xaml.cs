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
            

        }
        
       
        

        private void Open_File_Copy_Click(object sender, RoutedEventArgs e)
        {
            musteripopupxaml musteripopupxaml = new musteripopupxaml();
            musteripopupxaml.Show();
        }

        private void Open_File_Copy1_Click(object sender, RoutedEventArgs e)
        {
            
            aracpopup miete = new aracpopup();
            miete.Show();

        }

        private void Open_File_Copy2_Click(object sender, RoutedEventArgs e)
        {
            mietepopup miete = new mietepopup();
            miete.Show();

        }
    }
}
