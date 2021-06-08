using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Uygunitem.Models;
using System.Web.Security;

namespace Uygunitem.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        uygunitemdb db = new uygunitemdb();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult alogin(FormCollection form)
        {
            string kadi = form["username"].Trim();
            string sifre = form["password"].Trim();
            string md5sifre = Sifreleme.MD5Olustur(sifre);
            var kullanicivarmi = db.adminListesi.Where(x => x.admin_kadi.Equals(kadi) && x.admin_sifre.Equals(md5sifre)).FirstOrDefault();
            if(kullanicivarmi != null)
            {
                FormsAuthentication.SetAuthCookie(kullanicivarmi.admin_kadi, false);


                return RedirectToAction("/Index", "Admin");
            }
            ViewBag.hata = "Kullanıcı adı veya şifre yanlış!";
            return View("Index");

        }
    }
}