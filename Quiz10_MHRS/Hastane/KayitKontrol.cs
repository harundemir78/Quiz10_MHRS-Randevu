using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane
{
    class KayitKontrol
    {
      static HastaneDBEntities1 db = new HastaneDBEntities1();
       /// <summary> TC Değerleri
       /// 0:Kayıt Olabilir
       /// 1:TC 11 den Farklı
       /// 2:Farklı Tc
       /// 3:Alan Boş
       /// </summary>
       /// <param name="tc"></param>
       /// <returns></returns>
       public static string TcKontrol(string tc) 
        {
            if (tc=="")
            {
                return "TC Alanı Boş Bırakılamaz\n";
            }
            else if (tc.Length!=11)
            {
                return "TC Alanı 11 Den Farklı Olamaz\n";
            }

            else
            {
                return null;
            }
            
        }
       public static bool GirisKontrol(string tc,string pass)
        {
            var query=(from p in db.Personels where p.Tc==tc & p.Parola==pass select new{p.Tc,p.Parola}).ToList();
            var query2 = (from p in db.Hastas where p.Tc == tc & p.Parola == pass select new { p.Tc, p.Parola }).ToList();
            if (query.Count==0 && query2.Count==0)
            {
                return true;
            }
            return false;
        }
        public static string ParolaKontrol(string pass1,string pass2)
       {
           if (pass1!=pass2)
           {
               return "Parolalar Aynı Değil\n";
           }
           else
           {
               //regex
           }
           return null;
        }
        public static string TextKontol(string tc, string ad, string soyad, string dogumTarihi,string pass1, string pass2)
        {
            string mesaj = null;
            mesaj +=KayitKontrol.TcKontrol(tc);
            mesaj +=KayitKontrol.ParolaKontrol(pass1, pass2);
            if (ad == null)
            {
                mesaj += "\nAd Boş Bırakılamaz";
            }
            if (soyad == null)
                mesaj += "\nSoyad Boş Bırakılamaz";
            DateTime dt = Convert.ToDateTime(dogumTarihi);
            if ((dt.Year-DateTime.Now.Year) > 100)
                mesaj += "\nGeçerli Bir Doğum Tarihi Girin";
            return mesaj;
        }
      public static bool RandevuKontrol(DateTime saat)
       {
           //randevu saat Kontrol
           return false;
       }
      public static bool DoktorIzinKontol(int tc)
       {
           //doktor izin kontrolü
           return false;
       }


      public static void Brans(string brans)
      {
          throw new NotImplementedException();
      }
    }
}
