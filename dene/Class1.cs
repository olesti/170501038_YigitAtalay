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
                    k1.Kosten = reader[11].ToString()+ "€" ;
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
                MySqlCommand komut = new MySqlCommand("Delete From arac Where arac_no1=" + k.No  , con);
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
                MySqlCommand komut = new MySqlCommand("Delete From musteri Where mus_no=" + k.No, con);
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
                
                MySqlCommand komut = new MySqlCommand("Update testdb.arac SET marka='" + yarac.Marke.ToString() + "', yas='" + yarac.Alter.ToString() + "', kapı='" + yarac.Farbe.ToString() + "', kosten='" + yarac.Kosten.ToString()
                    + "', yakıt='" + yarac.Kraftstoff.ToString() + "', vites='" + yarac.Getriebetype.ToString() + "', km='" + yarac.Km.ToString() + "', kasa='" + yarac.Karosserientyp.ToString() + "', kazali='" + yarac.Schaden.ToString()
                    + "' Where plaka= '" + earac.Nummernschild.ToString() + "'", con);
                
                /*
                MySqlCommand komut = new MySqlCommand("Update testdb.arac SET marka='" + yarac.Marke.ToString() + "', yas='" + yarac.Alter.ToString() + "', yakıt='" + yarac.Kraftstoff.ToString() + "', vites='" + yarac.Getriebetype.ToString() + "', km='" + yarac.Km.ToString() + "', kasa='" + yarac.Karosserientyp.ToString() + "', kapı='" + yarac.Farbe.ToString() + "', model='" + yarac.Model.ToString() + "', kazali='" + yarac.Schaden.ToString() + "' Where plaka='" + earac.Nummernschild.ToString() + "'", con);
                */
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

        public MySqlConnection GetCon()
        {
            return con;
        }

        public void Guncelle1(mustericlass s)
        {

            try
            {
                MySqlCommand komut = new MySqlCommand("Update testdb.musteri SET mus_adi='" + s.Ad.ToString() + "', mus_soyadi='" + s.Soyad.ToString() + "', mus_tc='" + s.Tcnummer.ToString() + "', mus_tel='" + s.Telefonu.ToString() + "', mus_ehlino='" + s.Ehliyetno.ToString()
                    + "', mus_mail='" + s.Mail.ToString()  + "', mus_adres='" + s.Adresse.ToString() + "', mus_ehlitur='" + s.Ehliyett.ToString()
                    + "' Where mus_no= '" + s.No.ToString() + "'", con);
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
                MySqlCommand komut = new MySqlCommand ("Insert Into arac (arac_no1,plaka,marka,yas,yakıt,vites,km,kasa,kapı,model,kosten,kazali) Values ('"+"0"+ "','" + aracekle.Nummernschild + "','" + aracekle.Marke + "','" + aracekle.Alter + "','" + aracekle.Kraftstoff + "','" + aracekle.Getriebetype + "','" + aracekle.Km + "','" + aracekle.Karosserientyp + "','" + aracekle.Farbe + "','" + aracekle.Model + "','" + aracekle.Kosten + "','" + aracekle.Schaden+ "')", con);
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
                    k.Tcnummer = reader[3].ToString(); 
                    k.Telefonu = reader[4].ToString();
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
        

        public List<Mieteclass> Listelemiete()
        {
            //con = new MySqlConnection("Server=localhost;Database=testdb;Uid=root;Pwd='atalay528';AllowUserVariables=True;UseCompression=True;");

            try
            {
                List<Mieteclass> mietelist = new List<Mieteclass>();
                List<Mieteclass> mietelist2 = new List<Mieteclass>();

                MySqlDataAdapter baglayici = new MySqlDataAdapter();
                // cmd.CommandText = "Select * from musteri";
                //cmd.CommandType= CommandType.Text;
                MySqlCommand komut = new MySqlCommand("Select * from miete", con);
                con.Open();
                MySqlDataReader reader = komut.ExecuteReader();


                while (reader.Read())
                {
                    Mieteclass k = new Mieteclass();
                    k.Mieteno = Convert.ToInt16(reader[0].ToString());
                    k.Vorname = reader[1].ToString();
                    k.Nachname = reader[2].ToString();
                    k.Tcnummer = reader[3].ToString();
                    k.Telefonnumer = reader[4].ToString();
                    k.Email = reader[5].ToString();
                    k.Führerscheinno = reader[6].ToString();
                    k.Model = reader[7].ToString();
                    k.Marke = reader[8].ToString();
                    k.Nummerschild = reader[9].ToString();
                    k.Kraftstoff = reader[10].ToString();
                    k.Kosten = reader[11].ToString();
                    k.Rechnungsno = reader[12].ToString();
                    k.Ilkdate = Convert.ToDateTime(reader[13].ToString());
                    k.Sondate = Convert.ToDateTime(reader[14].ToString());
                    mietelist.Add(k);
                    
                    

                }
                return mietelist;


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
        
        public void Eklemiete(mustericlass musekle, aracclass arekle, Mieteclass saaaa)
        {
           
            Kira saaas = new Kira();
            try
            {
                MySqlCommand komut = new MySqlCommand("Insert Into miete ( Vorname, Nachname, Tcnummer, Telefonnummer, Email, Ehliyetno, Model, Marke, Nummerschild, Kraftstoff, GesamtKosten, Rechnungsno, Basdate, Sondate) Values " +
                    "('" + musekle.Ad + "','" + musekle.Soyad + "','" + musekle.Tcnummer + "','" + musekle.Telefonu + "','" + musekle.Mail + "','" + musekle.Ehliyetno + "','" + arekle.Model + "','" + arekle.Marke + "','" + arekle.Nummernschild + "','" + arekle.Kraftstoff + "','" + saaaa.Kosten + "','" + saaaa.Rechnungsno + "','" + saaaa.Ilkdate.ToString("yyyy-MM-dd") + "','" + saaaa.Sondate.ToString("yyyy-MM-dd") + "')", con);
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
        public void Silmiete(Mieteclass k)
        {
            try
            {
                MySqlCommand komut = new MySqlCommand("Delete From miete Where mieteno=" + k.Mieteno, con);
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
        public void Guncellemiete(Mieteclass s)
        {

            try
            {
                MySqlCommand komut = new MySqlCommand("Update testdb.miete SET Rechnungsno='" + s.Rechnungsno + "', GesamtKosten='" + s.Kosten
                    + "', Basdate='" + s.Ilkdate.ToString("yyyy-MM-dd") + "', Sondate='" + s.Sondate.ToString("yyyy-MM-dd") + "' Where mieteno= '" + s.Mieteno + "'", con);
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
    }
}
