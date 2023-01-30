using BusinessLayer.Concrete;
using BusinessLayer.Validaitons;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer;
using EventSceneCoreAppliciation.Models;
using Microsoft.AspNetCore.Mvc;
using PagedList.Core;
using System.Drawing.Printing;
using EventSceneCoreAppliciation.PagedList;
using DataAccessLayer.Concrete;

namespace EventSceneCoreAppliciation.Controllers
{
    public class KullaniciController : Controller
    {
        KullaniciManager kullanicim = new KullaniciManager(new EfKullaniciRepository());

        public IActionResult Index()
        {
            var kullanicilar = kullanicim.kullaniciListele();
            return View(kullanicilar);
        }

        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Kullanici kullanici)
        {
            KullaniciValidator kullaniciValidator = new KullaniciValidator();
            var result = kullaniciValidator.Validate(kullanici);

            if (result.IsValid)
            {
                kullanicim.kullaniciEkle(kullanici);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }

        public IActionResult sil(int id)
        {
            Kullanici kullanici = kullanicim.kullaniciGetById(id);
            kullanici.silindi = true;
            kullanicim.kullaniciGuncelle(kullanici);
            return RedirectToAction("Index");
        }

        public IActionResult guncelle(int id)
        {
            Kullanici kullanici = kullanicim.kullaniciGetById(id);
            return View(kullanici);
        }

        [HttpPost]
        public IActionResult guncelle(Kullanici kullanici)
        {
            KullaniciValidator kullaniciValidator = new KullaniciValidator();
            var result = kullaniciValidator.Validate(kullanici);

            if (result.IsValid)
            {
                kullanicim.kullaniciGuncelle(kullanici);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
    }
}