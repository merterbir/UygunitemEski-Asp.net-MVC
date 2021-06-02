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
    }
}