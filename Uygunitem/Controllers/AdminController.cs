using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Uygunitem.Models;

namespace Uygunitem.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        uygunitemdb db = new uygunitemdb();
        public ActionResult Index()
        {
            ViewModel viewModel = new ViewModel();
            viewModel.kategoriler = db.kategoriler.ToList();
            viewModel.urunler = db.urunler.ToList();
            viewModel.alt_kategoriler = db.alt_kategoriler.ToList();
            viewModel.cekilen_datalar = db.cekilen_datalar.ToList();
            viewModel.sponsorlar = db.sponsorlar.ToList();
            viewModel.uruntakip = db.uruntakip.ToList();
            viewModel.footer = db.footer.ToList();
            viewModel.yorumlar = db.yorumlar.ToList();
            viewModel.hataliUrunler = db.hataliUrunler.ToList();
            return View(viewModel);
        }
        public ActionResult urunEkleme()
        {
            ViewModel viewModel = new ViewModel();
            viewModel.kategoriler = db.kategoriler.ToList();
            viewModel.urunler = db.urunler.ToList();
            viewModel.alt_kategoriler = db.alt_kategoriler.ToList();
            viewModel.cekilen_datalar = db.cekilen_datalar.ToList();
            viewModel.sponsorlar = db.sponsorlar.ToList();
            viewModel.uruntakip = db.uruntakip.ToList();
            viewModel.footer = db.footer.ToList();
            viewModel.yorumlar = db.yorumlar.ToList();
            viewModel.hataliUrunler = db.hataliUrunler.ToList();
            return View(viewModel);
        }
        public ActionResult urunDuzenleme()
        {
            ViewModel viewModel = new ViewModel();
            viewModel.kategoriler = db.kategoriler.ToList();
            viewModel.urunler = db.urunler.ToList();
            viewModel.alt_kategoriler = db.alt_kategoriler.ToList();
            viewModel.cekilen_datalar = db.cekilen_datalar.ToList();
            viewModel.sponsorlar = db.sponsorlar.ToList();
            viewModel.uruntakip = db.uruntakip.ToList();
            viewModel.footer = db.footer.ToList();
            viewModel.yorumlar = db.yorumlar.ToList();
            viewModel.hataliUrunler = db.hataliUrunler.ToList();
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult fotoYukleme(HttpPostedFileBase file,FormCollection form)
        {
            ViewModel viewModel = new ViewModel();
            viewModel.kategoriler = db.kategoriler.ToList();
            viewModel.urunler = db.urunler.ToList();
            viewModel.alt_kategoriler = db.alt_kategoriler.ToList();
            viewModel.cekilen_datalar = db.cekilen_datalar.ToList();
            viewModel.sponsorlar = db.sponsorlar.ToList();
            viewModel.uruntakip = db.uruntakip.ToList();
            viewModel.footer = db.footer.ToList();
            viewModel.yorumlar = db.yorumlar.ToList();
            viewModel.hataliUrunler = db.hataliUrunler.ToList();
            try
            {
                if (file.ContentType == "image/jpeg" || file.ContentType == "image/jpg" || file.ContentType == "image/png" || file.ContentType == "image/gif")
                {
                urunler model = new urunler();
                model.urun_isim = form["ürün_adi"].Trim();
                model.urun_aciklama = form["ürün_aciklama"].Trim();
                model.anahtar_kelimeler = form["ürün_anahtar"].Trim();

                if (file != null && file.ContentLength > 0)
                {  
                        try
                        {
                            string path = Path.Combine(Server.MapPath("~/themes/images/products"),
                                                       Path.GetFileName(file.FileName));
                            file.SaveAs(path);
                            //ViewBag.Message = "File uploaded successfully";
                        }
                        catch (Exception ex)
                        {
                            ViewBag.Message = "ERROR:" + ex.Message.ToString();//
                        }
                }
                else
                {
                        ViewBag.Message = "ERROR: Dosya bulunamadı";//
                }
                model.urun_foto_path = "themes/images/products/" + file.FileName;
                model.üstkate_id = Convert.ToInt32(form["select1"].Trim());
                model.altkate_id = 1;
               
                db.urunler.Add(model);
                db.SaveChanges();
                //else
                //{
                //    ViewBag.Message = "You have not specified a file.";
                //}
                ViewBag.Message = "Ürün Ekleme Başarılı!";
                }
                else
                {
                    ViewBag.Message = "Dosya uzantısı geçersiz!";
                }

            }
            catch (Exception ex)
            {

                ViewBag.Message = "ERROR:" + ex.Message.ToString();
            }
            
            return View("urunEkleme",viewModel);
        }
        
        public ActionResult urunGetir(int id)
        {
            ViewModel viewModel = new ViewModel();
            viewModel.kategoriler = db.kategoriler.ToList();
            viewModel.urunler = db.urunler.ToList();
            viewModel.alt_kategoriler = db.alt_kategoriler.ToList();
            viewModel.cekilen_datalar = db.cekilen_datalar.ToList();
            viewModel.sponsorlar = db.sponsorlar.ToList();
            viewModel.uruntakip = db.uruntakip.ToList();
            viewModel.footer = db.footer.ToList();
            viewModel.yorumlar = db.yorumlar.ToList();
            viewModel.hataliUrunler = db.hataliUrunler.ToList();
            var urun = db.urunler.Find(id);
            viewModel.urunGetir = urun;
            return View("urunGetir", viewModel);
        }
        public ActionResult kategoriEkle()
        {
            ViewModel viewModel = new ViewModel();
            viewModel.kategoriler = db.kategoriler.ToList();
            viewModel.urunler = db.urunler.ToList();
            viewModel.alt_kategoriler = db.alt_kategoriler.ToList();
            viewModel.hatamesaj = "";
            return View("kategoriEkle",viewModel);
            
        }
        [HttpPost]
        public ActionResult kategoriEkleform(FormCollection form)
        {
            ViewModel viewModel = new ViewModel();
            viewModel.kategoriler = db.kategoriler.ToList();
            viewModel.urunler = db.urunler.ToList();
            viewModel.alt_kategoriler = db.alt_kategoriler.ToList();
            string katesorgu = form["KateEkle"].Trim();
            if (db.kategoriler.Where(x => x.kate_isim.Contains(katesorgu)).Count() == 1)
            {
                viewModel.hatamesaj = "Kategori Ekleme Başarısız! Aynı isimde kategori zaten mevcut!";
               
            }
            else
            {
                kategoriler kategori = new kategoriler();
                kategori.kate_isim = form["KateEkle"].Trim();
                db.kategoriler.Add(kategori);
                db.SaveChanges();
                viewModel.hatamesaj = "Kategori Ekleme Başarılı!";

            }
            
           
            return View("kategoriEkle",viewModel);
        }
        public ActionResult AltkategoriEkle()
        {
            ViewModel viewModel = new ViewModel();
            viewModel.kategoriler = db.kategoriler.ToList();
            viewModel.urunler = db.urunler.ToList();
            viewModel.alt_kategoriler = db.alt_kategoriler.ToList();
            viewModel.hatamesaj = "";

            return View("AltkategoriEkle",viewModel);
        }
        [HttpPost]
        public ActionResult altkategoriEkleform(FormCollection form)
        {
            ViewModel viewModel = new ViewModel();
            viewModel.kategoriler = db.kategoriler.ToList();
            viewModel.urunler = db.urunler.ToList();
            viewModel.alt_kategoriler = db.alt_kategoriler.ToList();
            string katesorgu = form["KateEkle"].Trim();
            int üstkatesorgu = Convert.ToInt32(form["select1"].Trim());
            if (db.alt_kategoriler.Where(x => x.altkate_isim.Contains(katesorgu)).Where(x => x.üstkate_id == üstkatesorgu).Count() == 1)
            {
                viewModel.hatamesaj = "Alt Kategori Ekleme Başarısız! Aynı isimde alt kategori zaten mevcut!";

            }
            else
            {
                alt_kategoriler kategori = new alt_kategoriler();
                kategori.altkate_isim = form["KateEkle"].Trim();
                kategori.üstkate_id = Convert.ToInt32(form["select1"].Trim());
                db.alt_kategoriler.Add(kategori);
                db.SaveChanges();
                viewModel.hatamesaj = "Alt Kategori Ekleme Başarılı!";

            }


            return View("AltkategoriEkle", viewModel);
        }

        [HttpPost]
        public ActionResult urunGuncelle(ViewModel p1)
        {
            var urun = db.urunler.Find(p1.urunGetir.urun_id);
            
            urun.anahtar_kelimeler = p1.urunGetir.anahtar_kelimeler;
            urun.urun_aciklama = p1.urunGetir.urun_aciklama;
            urun.urun_isim = p1.urunGetir.urun_isim;
            //urun.üstkate_id = p1.urunGetir.üstkate_id;
            //urun.altkate_id = p1.urunGetir.altkate_id;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult kategoriDuzenleme()
        {
            ViewModel viewModel = new ViewModel();
            viewModel.kategoriler = db.kategoriler.ToList();
            return View("kategoriDuzenleme",viewModel);
        }
        public ActionResult kategoriGetir(int id)
        {
            ViewModel viewModel = new ViewModel();
            viewModel.kategoriler = db.kategoriler.ToList();
            viewModel.hatamesaj = "";
            var kategori = db.kategoriler.Find(id);
            viewModel.kategoriGetir = kategori;
            return View("kategoriGetir", viewModel);
        }
        [HttpPost]
        public ActionResult kategoriGuncelle(ViewModel p1)
        {
            ViewModel viewModel = new ViewModel();
            viewModel.kategoriler = db.kategoriler.ToList();
            var kategori = db.kategoriler.Find(p1.kategoriGetir.kate_id);

            

            string katesorgu = p1.kategoriGetir.kate_isim;
            if (db.kategoriler.Where(x => x.kate_isim.Contains(katesorgu)&&x.kate_id !=kategori.kate_id).Count() == 1)
            {
                viewModel.hatamesaj = "Kategori Güncelleme Başarısız! Aynı isimde kategori zaten mevcut!";

            }
            else
            {
                kategori.kate_isim = p1.kategoriGetir.kate_isim;
                db.SaveChanges();
                viewModel.hatamesaj = "Kategori Güncelleme Başarılı!";

            }
           
            return View("kategoriGetir",viewModel);
        }
        public ActionResult altkategoriDuzenleme()
        {
            ViewModel viewModel = new ViewModel();
            viewModel.alt_kategoriler = db.alt_kategoriler.ToList();
            return View("altkategoriDuzenleme", viewModel);
        }
        public ActionResult altkategoriGetir(int id)
        {
            ViewModel viewModel = new ViewModel();
            viewModel.kategoriler = db.kategoriler.ToList();
            viewModel.alt_kategoriler = db.alt_kategoriler.ToList();
            viewModel.hatamesaj = "";
            var altkategori = db.alt_kategoriler.Find(id);
            viewModel.altkategoriGetir = altkategori;
            viewModel.üstkstring = db.kategoriler.Where(x => x.kate_id == altkategori.üstkate_id).Select(x => x.kate_isim).FirstOrDefault();
            viewModel.üstkint = db.kategoriler.Where(x => x.kate_id == altkategori.üstkate_id).Select(x => x.kate_id).FirstOrDefault();
            return View("altkategoriGetir", viewModel);
        }
        [HttpPost]
        public ActionResult altkategoriGuncelle(ViewModel p1,FormCollection form)
        {
            ViewModel viewModel = new ViewModel();
            viewModel.kategoriler = db.kategoriler.ToList();
            viewModel.alt_kategoriler = db.alt_kategoriler.ToList();
            var kategori = db.alt_kategoriler.Find(p1.altkategoriGetir.altkate_id);
            int üstkatesorgu =Convert.ToInt32( form["üstkate"].Trim());



            string katesorgu = p1.altkategoriGetir.altkate_isim;
            if (db.alt_kategoriler.Where(x => x.altkate_isim.Contains(katesorgu)).Where(x => x.üstkate_id == üstkatesorgu).Count() == 1)
            {
                viewModel.hatamesaj = "Alt Kategori Düzenleme Başarısız! Aynı isimde alt kategori zaten mevcut!";
                viewModel.üstkint = üstkatesorgu;
                viewModel.üstkstring = db.kategoriler.Where(x => x.kate_id == üstkatesorgu).Select(x => x.kate_isim).FirstOrDefault();

            }
            else
            {
                kategori.altkate_isim = p1.altkategoriGetir.altkate_isim;
                kategori.üstkate_id = üstkatesorgu;
                db.SaveChanges();
                viewModel.hatamesaj = "Alt Kategori Düzenleme Başarılı!";
                viewModel.üstkint = üstkatesorgu;
                viewModel.üstkstring = db.kategoriler.Where(x => x.kate_id == üstkatesorgu).Select(x => x.kate_isim).FirstOrDefault();

            }

            return View("altkategoriGetir",viewModel);
        }
    }
}