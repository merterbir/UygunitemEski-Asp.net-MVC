using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uygunitem
{
    public static class urunKontrol
    {

       public static string[] parcala(string anahtar)
        {
            string[] yeni = anahtar.Split(',');
            return yeni;
        }
        public static bool anahtarKontrol(string kelime,string[] anahtarlar)
        {
            foreach (string anahtar in anahtarlar)
            {
                if (kelime.Contains(anahtar))
                    return true;
            }

            return false;
        }
        public static string[] parcalaUrun(string anahtar)
        {
            string[] yeni = anahtar.Split(' ');
            return yeni;
        }
    }
}