using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uygunitem.Models
{
   public class ViewModel
   {
       public IEnumerable<urunler> urunler { get; set; }
        public IEnumerable<kategoriler> kategoriler { get; set; }
        public IEnumerable<alt_kategoriler> alt_kategoriler { get; set; }

        public IEnumerable<cekilen_datalar> cekilen_datalar { get; set; }

        public IEnumerable<hakkimizda> hakkimizda { get; set; }

        public IEnumerable<footer> footer { get; set; }
        public IEnumerable<yorumlar> yorumlar { get; set; }
        public IEnumerable<uruntakip>uruntakip { get; set; }
        public IEnumerable<hataliUrunler> hataliUrunler { get; set; }
        public IEnumerable<sponsorlar> sponsorlar { get; set; }
        public string[] anahtarKelimeler { get; set; }

        public int id { get; set; }

        public IEnumerable firmalar { get; set; }
        public urunler urunGetir { get; set; }
        public string hatamesaj { get; set; }


    }
}