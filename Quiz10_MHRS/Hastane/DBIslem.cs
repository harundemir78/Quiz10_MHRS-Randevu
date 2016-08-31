using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hastane
{
    class DBIslem
    {
       public static HastaneDBEntities1 db = new HastaneDBEntities1();
        public static string user = "";
       static Hasta hs = new Hasta();
       static Personel per = new Personel();
        public static string KullaniciGiris(string tc, string parola)
        {
            string mesaj;
            mesaj = KayitKontrol.TcKontrol(tc);


            if (mesaj == null && parola != null)
            {
                var query = (from p in db.Hastas where p.Tc == tc && p.Parola == parola select p).ToList();
                var query2 = (from p in db.Personels where p.Tc == tc && p.Parola == parola select p).ToList();
                if (query.Count != 0 || query2.Count != 0)
                {
                    foreach (var item in query)
                    {
                        user = item.Ad + " " + item.Soyad;
                        return mesaj;
                    }
                    foreach (var item in query2)
                    {
                        user = item.Ad + " " + item.Soyad;
                        return item.TurID.ToString();
                    }
                }
                else if (query.Count == 0 || query2.Count == 0 )
                {
                    mesaj = "Kullanıcı Kayıtlı Değil";
                }
                
               
            }
            if (parola=="")
            {
                mesaj += "\nParola Boş Bırakılamaz"; 
            }

            return mesaj;

        }
        public static string HastaKayit(string tc, string ad, string soyad, string dogumTarihi, bool cins, string pass1, string pass2)
        {
            string mesaj = KayitKontrol.TextKontol(tc,ad,soyad,dogumTarihi,pass1,pass2);
            if (mesaj=="")
            {
                hs.Tc = tc;
                hs.Ad = ad;
                hs.Soyad = soyad;
                hs.DogumTarihi = dogumTarihi;
                hs.Cinsiyet = cins;
                hs.Parola = pass1;
                hs.OlusturulmaTarihi = DateTime.Now.ToShortDateString();
                db.Hastas.Add(hs);
                
               int a= db.SaveChanges();
               if (a!=0)
               {
                   mesaj = "Hasta Kaydı Yapıldı";
               }
            }



            return mesaj;
        }
        public static void  PersonelTurGetir(ComboBox combo )
        { 
        var query=(from p in db.PersonelTurs select p);
      
        combo.DataSource = query.ToList();
        combo.DisplayMember = "Tur";
        combo.ValueMember = "PersonelTurID";
        }
        public static void PersonelBransGetir(ComboBox combo)
        {
            var query = (from p in db.Brans1 select p).ToList();
            combo.DataSource = query;
            combo.DisplayMember = "Ad";
            combo.ValueMember = "BransID";
        }
        public static string PersonelKayit(int tur,string tc,string ad,string soyad,bool cins,byte[]resimPath,string pass1,string pass2)
        {
            
            string mesaj="";
            bool b = true;
            mesaj+= KayitKontrol.TextKontol(tc,ad,soyad,null,pass1,pass2);
            if (mesaj=="" && resimPath.Count()!=0)
            {
                
                per.Resim = resimPath;
                per.Tc = tc;
                per.Ad = ad;
                per.Soyad = soyad;
                per.TurID = tur;
                per.Parola = pass1;
                
                per.GirisTarihi = DateTime.Now.ToShortDateString();
                per.AktifMi = cins;
                db.Personels.Add(per);
                int a =db.SaveChanges();
                if (a != 0)
                {
                    mesaj = "Personel Eklendi";
                }
                else
                {
                    mesaj = "Personel Eklenemedi";
                }
            }
            
	
            
            return mesaj;
        }

        public static void BransEkle(string brans)
        {
            KayitKontrol.Brans(brans);
        }
    }
}
