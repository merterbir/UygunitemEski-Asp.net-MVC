using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public IEnumerable<menuKategoriler> menuKategoriler { get; set; }
        public string[] anahtarKelimeler { get; set; }
        public string[] urunKelimeler { get; set; }
        public int id { get; set; }
        public int üstid { get; set; }
        public IEnumerable firmalar { get; set; }
        public urunler urunGetir { get; set; }
        public kategoriler kategoriGetir { get; set; }
        public menuKategoriler menukategoriGetir { get; set; }
        public alt_kategoriler altkategoriGetir { get; set; }
        public string hatamesaj { get; set; }
        public string üstkstring { get; set; }
        public int üstkint { get; set; }
        public string[] firmalargrafik { get; set; }
        public string[] fiyatlargrafik { get; set; }
        public Dictionary<string,string> tablo { get; set; }
        public List<ViewModel> list { get; set; }

        public string ArananText { get; set; }
        public IQueryable<urunler> arananUrunler { get; set; }
        public IEnumerable<SelectListItem> üstKategoriler { get; set; }
        public IEnumerable<SelectListItem> altKategoriler { get; set; }
        public Boolean sorgu { get; set; }
        public IEnumerable<adminListesi> adminListesi { get; set; }


    }
}