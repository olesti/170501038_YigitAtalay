﻿using System;
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
                    k1.No = reader[10].ToString();
                    k1.Marke = reader[1].ToString();
                    k1.Model = reader[8].ToString();
                    k1.Alter = Convert.ToInt32(reader[2].ToString());
                    k1.Kraftstoff = reader[3].ToString();
                    k1.Nummernschild = reader[0].ToString();
                    k1.Karosserientyp = reader[6].ToString();
                    k1.Getriebetype = reader[4].ToString();
                    k1.Km = reader[5].ToString();
                    k1.Schaden = reader[9].ToString(); 
                    k1.Farbe =reader[7].ToString();
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
        public void Sil(aracclass k )
        {
            try
            {
                MySqlCommand komut = new MySqlCommand("Delete From arac Where arac_no1=" + k.No + "", con);
                con.Open();
                komut.ExecuteNonQuery();
            }
            catch (Exception)
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
        public void Sil1(mustericlass k)
        {
            try
            {
                MySqlCommand komut = new MySqlCommand("Delete From arac Where mus_no=" + k.No + "", con);
                con.Open();
                komut.ExecuteNonQuery();
            }
            catch (Exception)
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
        public void Guncelle(aracclass earac, aracclass yarac)
        {
            try
            {
                MySqlCommand komut = new MySqlCommand("Update arac SET plaka='" + yarac.Nummernschild + "',marka='" + yarac.Marke + "',yas='" + yarac.Alter + "',yakıt='" + yarac.Kraftstoff + "',vites='" + yarac.Getriebetype 
                    + "',km='" + yarac.Km + "',kasa='" + yarac.Karosserientyp + "',kapı='" + yarac.Farbe + "',model='" + yarac.Model + "',kazali='" + yarac.Schaden  + "' Where plaka=" + earac.Nummernschild + "",con);
                con.Open();
                komut.ExecuteNonQuery();
            }
            catch (Exception)
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
        public void Ekle(aracclass aracekle)
        {
            try
            {
                MySqlCommand komut = new MySqlCommand ("Insert Into arac (arac_no1,plaka,marka,yas,yakıt,vites,km,kasa,kapı,model,kazali) Values ('"+aracekle.No+ "','" + aracekle.Nummernschild + "','" + aracekle.Marke + "','" + aracekle.Alter + "','" + aracekle.Kraftstoff + "','" + aracekle.Getriebetype + "','" + aracekle.Km + "','" + aracekle.Karosserientyp + "','" + aracekle.Farbe + "','" + aracekle.Model + "','" + aracekle.Schaden+ "')", con);
                con.Open();
                komut.ExecuteNonQuery();
            }
            catch (Exception)
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
        public void Ekle1(mustericlass musekle)
        {
            try
            {
                MySqlCommand komut = new MySqlCommand("Insert Into musteri (mus_adi,mus_soyadi,mus_tc,mus_tel,mus_mail,mus_adres,mus_ehlitur,mus_ehlino) Values ('" + musekle.Ad + "','" + musekle.Soyad + "','" + musekle.Tcnummer + "','" + musekle.Telefonu + "','" + musekle.Mail + "','" + musekle.Adresse + "','" + musekle.Ehliyett + "','" + musekle.Ehliyetno+ "')", con);
                con.Open();
                komut.ExecuteNonQuery();
            }
            catch (Exception)
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
                    k.Telefonu = reader[4].ToString();
                    k.Tcnummer = reader[3].ToString(); 
                    k.Mail=reader[5].ToString();
                    k.Adresse = reader[6].ToString();
                    k.Ehliyetno=Convert.ToInt32(reader[8].ToString());
                    k.Ehliyett = reader[7].ToString();
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
