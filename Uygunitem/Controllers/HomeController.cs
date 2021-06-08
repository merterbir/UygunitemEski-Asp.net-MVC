using System;
using System.Linq;
using System.Web.Mvc;
using Uygunitem.Models;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.IO;
using System.Collections.Generic;

namespace Uygunitem.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        uygunitemdb db = new uygunitemdb();
        public ActionResult Index()
        {
            ViewModel viewModel = new ViewModel();
            viewModel.kategoriler = db.kategoriler.ToList();
            viewModel.urunler = db.urunler.ToList();
            viewModel.alt_kategoriler = db.alt_kategoriler.ToList();
            viewModel.footer = db.footer.ToList();
            viewModel.menuKategoriler = db.menuKategoriler.ToList();

            return View(viewModel);
        }

        public ActionResult _Layout()
        {
            ViewModel viewModel = new ViewModel();
            viewModel.kategoriler = db.kategoriler.ToList();
            viewModel.urunler = db.urunler.ToList();
            viewModel.alt_kategoriler = db.alt_kategoriler.ToList();
            viewModel.cekilen_datalar = db.cekilen_datalar.ToList();
            viewModel.footer = db.footer.ToList();
            viewModel.yorumlar = db.yorumlar.ToList();
            viewModel.hataliUrunler = db.hataliUrunler.ToList();
            viewModel.sponsorlar = db.sponsorlar.ToList();
            viewModel.menuKategoriler = db.menuKategoriler.ToList();



            return View(viewModel);
        }
        public ActionResult kategoriler(int id = 0, int üstid = 0)
        {
            ViewModel viewModel = new ViewModel();
            viewModel.kategoriler = db.kategoriler.ToList();
            viewModel.urunler = db.urunler.ToList();
            viewModel.alt_kategoriler = db.alt_kategoriler.ToList();
            viewModel.id = id;
            viewModel.menuKategoriler = db.menuKategoriler.ToList();
            viewModel.footer = db.footer.ToList();
            viewModel.üstid = üstid;
            return View("kategoriler", viewModel);
        }
        public ActionResult üstKategoriler(int id = 0)
        {
            ViewModel viewModel = new ViewModel();
            viewModel.kategoriler = db.kategoriler.ToList();
            viewModel.urunler = db.urunler.ToList();
            viewModel.alt_kategoriler = db.alt_kategoriler.ToList();
            viewModel.id = id;

            viewModel.menuKategoriler = db.menuKategoriler.ToList();
            viewModel.footer = db.footer.ToList();

            return View("üstKategoriler", viewModel);


        }
        public ActionResult hakkimizda()
        {
            ViewModel viewModel = new ViewModel();
            viewModel.kategoriler = db.kategoriler.ToList();
            viewModel.urunler = db.urunler.ToList();
            viewModel.alt_kategoriler = db.alt_kategoriler.ToList();
            viewModel.hakkimizda = db.hakkimizda.ToList();
            viewModel.footer = db.footer.ToList();
            viewModel.menuKategoriler = db.menuKategoriler.ToList();
            return View(viewModel);
        }
        public ActionResult ileti()
        {
            ViewModel viewModel = new ViewModel();
            viewModel.kategoriler = db.kategoriler.ToList();
            viewModel.urunler = db.urunler.ToList();
            viewModel.alt_kategoriler = db.alt_kategoriler.ToList();
            viewModel.hakkimizda = db.hakkimizda.ToList();
            viewModel.footer = db.footer.ToList();
            viewModel.menuKategoriler = db.menuKategoriler.ToList();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult ileti(FormCollection form)
        {
            ViewModel viewModel = new ViewModel();
            viewModel.kategoriler = db.kategoriler.ToList();
            viewModel.urunler = db.urunler.ToList();
            viewModel.alt_kategoriler = db.alt_kategoriler.ToList();
            viewModel.hakkimizda = db.hakkimizda.ToList();
            viewModel.footer = db.footer.ToList();
            viewModel.menuKategoriler = db.menuKategoriler.ToList();
            mesaj model = new mesaj();
            model.ad = form["ad"].Trim();
            model.email = form["email"].Trim();
            model.konu = form["konu"].Trim();
            model.mesaj1 = form["message"].Trim();
            model.tarih = DateTime.Now;
            db.mesaj.Add(model);
            db.SaveChanges();
            return View(viewModel);
        }
        public ActionResult urunDetay(int id = 0)
        {
            ViewModel viewModel = new ViewModel();
            viewModel.kategoriler = db.kategoriler.ToList();
            viewModel.urunler = db.urunler.ToList();
            viewModel.alt_kategoriler = db.alt_kategoriler.ToList();
            viewModel.menuKategoriler = db.menuKategoriler.ToList();
            viewModel.cekilen_datalar = db.cekilen_datalar.ToList();
            viewModel.id = id;
            viewModel.footer = db.footer.ToList();
            viewModel.yorumlar = db.yorumlar.ToList();
            viewModel.hataliUrunler = db.hataliUrunler.ToList();
            viewModel.sponsorlar = db.sponsorlar.ToList();

            viewModel.tablo = new Dictionary<string, string>();

            if (db.urunler.Where(x => x.urun_id == id).Count() != 0)
            {
                viewModel.anahtarKelimeler = urunKontrol.parcala(db.urunler.Where(x => x.urun_id == id).Select(x => x.anahtar_kelimeler).FirstOrDefault());
                var ürünler = db.cekilen_datalar.Where(x => viewModel.anahtarKelimeler.All(a => x.cekilen_isim.Contains(a))).OrderBy(x => x.cekilen_tarih);
                
                foreach (var item in ürünler)
                {
                    viewModel.urunKelimeler = urunKontrol.parcalaUrun(item.cekilen_isim);
                    if(viewModel.tablo.ContainsKey(item.cekilen_firma)&& viewModel.anahtarKelimeler.All(a => viewModel.urunKelimeler.Any(c => c.Equals(a))))
                    {
                        string gfiyat = item.cekilen_fiyat.ToString();
                        viewModel.tablo[item.cekilen_firma] += gfiyat.Replace(",",".")+",";
                    }
                    else if(viewModel.anahtarKelimeler.All(a => viewModel.urunKelimeler.Any(c => c.Equals(a))))
                    {
                        string gfiyat = item.cekilen_fiyat.ToString();
                        viewModel.tablo.Add(item.cekilen_firma, gfiyat.Replace(",", ".") + ",");
                    }
                }
            }
            // viewModel.firmalar = db.cekilen_datalar.Where(x => viewModel.anahtarKelimeler.All(a => x.cekilen_isim.Contains(a))).Where(x => x.cekilen_durum == 1).Select(x => x.cekilen_firma).ToList();


            return View("urunDetay", viewModel);
        }
        [HttpPost]
        public ActionResult urunDetay(FormCollection yorumform, int id = 0)
        {
            yorumlar model = new yorumlar();
            model.isim = yorumform["yorum_ad"].Trim();
            model.mail = yorumform["yorum_email"].Trim();
            model.yorum = yorumform["yorum_yorum"].Trim();
            model.tarih = DateTime.Now;
            model.urun_id = id;

            model.yorumDurum = 0;
            model.urun_isim = db.urunler.Where(x => x.urun_id == id).Select(x => x.urun_isim).Single();
            db.yorumlar.Add(model);
            db.SaveChanges();
            ViewModel viewModel = new ViewModel();
            viewModel.sponsorlar = db.sponsorlar.ToList();
            viewModel.kategoriler = db.kategoriler.ToList();
            viewModel.urunler = db.urunler.ToList();
            viewModel.alt_kategoriler = db.alt_kategoriler.ToList();
            viewModel.tablo = new Dictionary<string, string>();
            viewModel.cekilen_datalar = db.cekilen_datalar.ToList();
            viewModel.sorgu = true; 
            viewModel.menuKategoriler = db.menuKategoriler.ToList();
            viewModel.id = id;
            viewModel.footer = db.footer.ToList();
            viewModel.yorumlar = db.yorumlar.ToList();
            viewModel.hataliUrunler = db.hataliUrunler.ToList();
            if (db.urunler.Where(x => x.urun_id == id).Count() != 0)
            {
                viewModel.anahtarKelimeler = urunKontrol.parcala(db.urunler.Where(x => x.urun_id == id).Select(x => x.anahtar_kelimeler).FirstOrDefault());
            }
            if (db.urunler.Where(x => x.urun_id == id).Count() != 0)
            {
                viewModel.anahtarKelimeler = urunKontrol.parcala(db.urunler.Where(x => x.urun_id == id).Select(x => x.anahtar_kelimeler).FirstOrDefault());
                var ürünler = db.cekilen_datalar.Where(x => viewModel.anahtarKelimeler.All(a => x.cekilen_isim.Contains(a))).OrderBy(x => x.cekilen_tarih);

                foreach (var item in ürünler)
                {
                    viewModel.urunKelimeler = urunKontrol.parcalaUrun(item.cekilen_isim);
                    if (viewModel.tablo.ContainsKey(item.cekilen_firma) && viewModel.anahtarKelimeler.All(a => viewModel.urunKelimeler.Any(c => c.Equals(a))))
                    {
                        string gfiyat = item.cekilen_fiyat.ToString();
                        viewModel.tablo[item.cekilen_firma] += gfiyat.Replace(",", ".") + ",";
                    }
                    else if (viewModel.anahtarKelimeler.All(a => viewModel.urunKelimeler.Any(c => c.Equals(a))))
                    {
                        string gfiyat = item.cekilen_fiyat.ToString();
                        viewModel.tablo.Add(item.cekilen_firma, gfiyat.Replace(",", ".") + ",");
                    }
                }
            }

            return View("urunDetay",viewModel);

        }

        [HttpPost]
        public ActionResult urunTakip(FormCollection takipform, int id)
        {
            
            ViewModel viewModel = new ViewModel();
            viewModel.kategoriler = db.kategoriler.ToList();
            viewModel.urunler = db.urunler.ToList();
            viewModel.alt_kategoriler = db.alt_kategoriler.ToList();
            viewModel.cekilen_datalar = db.cekilen_datalar.ToList();
            viewModel.uruntakip = db.uruntakip.ToList();
            viewModel.menuKategoriler = db.menuKategoriler.ToList();
            viewModel.sponsorlar = db.sponsorlar.ToList();
            viewModel.id = id;
            viewModel.footer = db.footer.ToList();
            viewModel.yorumlar = db.yorumlar.ToList();
            viewModel.hataliUrunler = db.hataliUrunler.ToList();
            if (db.urunler.Where(x => x.urun_id == id).Count() != 0)
            {
                viewModel.anahtarKelimeler = urunKontrol.parcala(db.urunler.Where(x => x.urun_id == id).Select(x => x.anahtar_kelimeler).FirstOrDefault());
            }
            uruntakip model = new uruntakip();
            model.kullanici_isim = takipform["takip_ad"].Trim();
            model.kullanici_mail = takipform["takip_email"].Trim();
            model.takip_tarih = DateTime.Now;
            model.takip_urun = id;
            model.takip_sonfiyat = viewModel.cekilen_datalar.Where(x => viewModel.anahtarKelimeler.All(a => x.cekilen_isim.Contains(a))).Where(x => x.cekilen_durum == 1).OrderBy(x => x.cekilen_fiyat).Select(x => x.cekilen_fiyat).FirstOrDefault();
            model.takip_anahtarkelime = db.urunler.Where(x => x.urun_id == id).Select(x => x.anahtar_kelimeler).FirstOrDefault();
            db.uruntakip.Add(model);
            db.SaveChanges();

            return RedirectToAction("urunDetay",new {id = id});
        }
        [HttpPost]
        public ActionResult hataliUrun(int dbSatir, int id)
        {
            ViewModel viewModel = new ViewModel();
            viewModel.kategoriler = db.kategoriler.ToList();
            viewModel.urunler = db.urunler.ToList();
            viewModel.alt_kategoriler = db.alt_kategoriler.ToList();
            viewModel.cekilen_datalar = db.cekilen_datalar.ToList();
            viewModel.sponsorlar = db.sponsorlar.ToList();
            viewModel.menuKategoriler = db.menuKategoriler.ToList();
            viewModel.uruntakip = db.uruntakip.ToList();
            viewModel.id = id;
            viewModel.footer = db.footer.ToList();
            viewModel.yorumlar = db.yorumlar.ToList();
            viewModel.hataliUrunler = db.hataliUrunler.ToList();
            
            if (db.urunler.Where(x => x.urun_id == id).Count() != 0)
            {
                viewModel.anahtarKelimeler = urunKontrol.parcala(db.urunler.Where(x => x.urun_id == id).Select(x => x.anahtar_kelimeler).FirstOrDefault());
            }
            if(db.hataliUrunler.Where(x => x.hataliUrun_dbSatir == dbSatir).Count() ==0)
            {
                hataliUrunler model = new hataliUrunler();
                model.hataliUrun_dbSatir = dbSatir;
                model.hataliUrun_firma = db.cekilen_datalar.Where(x=> x.cekilen_data_id == dbSatir).Where(x => x.cekilen_durum == 1).Select(x => x.cekilen_firma).FirstOrDefault();
                model.hataliUrun_id = id;
                model.hataliUrun_link = db.cekilen_datalar.Where(x => x.cekilen_data_id == dbSatir).Where(x => x.cekilen_durum == 1).Select(x => x.cekilen_url).FirstOrDefault();
                model.hataliUrun_adi = db.cekilen_datalar.Where(x => x.cekilen_data_id == dbSatir).Where(x => x.cekilen_durum == 1).Select(x => x.cekilen_isim).FirstOrDefault();

                db.hataliUrunler.Add(model);
                db.SaveChanges();
            }

            return RedirectToAction("urunDetay", new { id = id });
        }
        public ActionResult arananUrun (ViewModel p1)
        {

            return RedirectToAction("arananUrun", p1);
        }
        [HttpPost]
        public ActionResult aramaSonuclari(FormCollection form)
        {
            ViewModel viewModel = new ViewModel();
            viewModel.kategoriler = db.kategoriler.ToList();
            viewModel.urunler = db.urunler.ToList();
            viewModel.alt_kategoriler = db.alt_kategoriler.ToList();
            viewModel.menuKategoriler = db.menuKategoriler.ToList(); 
            viewModel.footer = db.footer.ToList();
            string aramaText = form["searchtext"].Trim();
            string[] aramaListe = aramaText.Split(' ');
            viewModel.ArananText= form["searchtext"].Trim();
            viewModel.arananUrunler = db.urunler.Where(x => aramaListe.All(a => x.urun_isim.Contains(a)));
            if(aramaText == "")
            {
                return View("Index",viewModel);
            }
            else
            {
                return View("arananUrun", viewModel);
            }
            
        }

    }
}