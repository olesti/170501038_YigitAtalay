using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using System.Data;

namespace GetLos_App
{
    internal class Class1
    {
        MySqlConnection con= new MySqlConnection("Server=localhost;Database=testdb;Uid=root;Pwd='atalay528';AllowUserVariables=True;UseCompression=True;");
        MySqlCommand cmd;

        public void class1()
        {

        }

        public List<aracclass> Listele1()
        {

            try
            {
                List<aracclass> araclist = new List<aracclass>();

                MySqlDataAdapter baglayici = new MySqlDataAdapter();
                // cmd.CommandText = "Select * from musteri";
                //cmd.CommandType= CommandType.Text;
                MySqlCommand komut = new MySqlCommand("Select * from arac", con);
                con.Open();
                MySqlDataReader reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    MySqlDataAdapter baglayici1 = new MySqlDataAdapter();
                    // cmd.CommandText = "Select * from musteri";
                    //cmd.CommandType= CommandType.Text;
                    aracclass k1 = new aracclass();
                    k1.No = Convert.ToInt32(reader[0].ToString());
                    k1.Marke = reader[2].ToString();
                    k1.Model = reader[10].ToString();
                    k1.Alter = Convert.ToInt32(reader[3].ToString());
                    k1.Kraftstoff = reader[4].ToString();
                    k1.Nummernschild = reader[1].ToString();
                    k1.Karosserientyp = reader[8].ToString();
                    k1.Getriebetype = reader[5].ToString();
                    k1.Km = reader[6].ToString();
                    k1.Motorleistung = reader[7].ToString();
                    k1.Schaden = reader[10].ToString(); 
                    araclist.Add(k1);
                }
                return araclist;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        public List<mustericlass> Listele()
        {
            //con = new MySqlConnection("Server=localhost;Database=testdb;Uid=root;Pwd='atalay528';AllowUserVariables=True;UseCompression=True;");

            try
            {
                List<mustericlass> musterilist = new List<mustericlass>();
                List<aracclass> araclist = new List<aracclass>();

                MySqlDataAdapter baglayici = new MySqlDataAdapter();
                // cmd.CommandText = "Select * from musteri";
                //cmd.CommandType= CommandType.Text;
                MySqlCommand komut = new MySqlCommand("Select * from musteri", con);
                con.Open();
                MySqlDataReader reader = komut.ExecuteReader();
                

                while (reader.Read())
                {
                    mustericlass k = new mustericlass();
                    k.No = Convert.ToInt32(reader[0].ToString());
                    k.Ad = reader[1].ToString();
                    k.Soyad = reader[2].ToString();
                    k.Telefonu = reader[5].ToString();
                    k.Tcnummer = reader[3].ToString(); 
                    k.Mail=reader[6].ToString();
                    k.Adresse = reader[7].ToString();
                    k.Dogum = DateTime.Parse(reader[4].ToString()).ToShortDateString();
                    k.Ehliyetno=Convert.ToInt32(reader[9].ToString());
                    k.Ehliyett = reader[8].ToString();
                    musterilist.Add(k);

                   
                }
                return musterilist;
                

            }
            catch
            {
                throw;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            
        }
    }
}
