using BusinessLayer.Concrete;
using BusinessLayer.Validaitons;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer;
using EventSceneCoreAppliciation.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventSceneCoreAppliciation.Controllers
{
    public class BiletController : Controller
    {
        BiletManager biletm = new BiletManager(new EfBiletRepository());
        SeansManager seansm = new SeansManager(new EfSeansRepository());
        KullaniciManager kullanicim = new KullaniciManager(new EfKullaniciRepository());

        public IActionResult Index()
        {
            var biletler = biletm.biletListele();
            return View(biletler);
        }

        [HttpGet]
        public IActionResult Ekle()
        {
            BiletSeansKullaniciModel model = new BiletSeansKullaniciModel();
            model.seansModel = seansm.seansListele();
            model.kullaniciModel = kullanicim.kullaniciListele();
            model.biletModel = new Bilet();
            return View(model);
        }

        [HttpPost]
        public IActionResult Ekle(Bilet bilet)
        {
            BiletValidator biletValidator = new BiletValidator();
            var result = biletValidator.Validate(bilet);

            if (result.IsValid)
            {
                biletm.biletEkle(bilet);
                return RedirectToAction("Index");
            }

            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                BiletSeansKullaniciModel model = new BiletSeansKullaniciModel();
                model.seansModel = seansm.seansListele();
                model.kullaniciModel = kullanicim.kullaniciListele();
                model.biletModel = bilet;
                return View(model);
            }
        }

        public IActionResult Sil(int id)
        {
            Bilet bilet = biletm.biletGetById(id);
            bilet.silindi = true;
            biletm.biletGuncelle(bilet);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Guncelle(int id)
        {
            BiletSeansKullaniciModel model = new BiletSeansKullaniciModel();
            model.seansModel=seansm.seansListele();
            model.kullaniciModel=kullanicim.kullaniciListele();
            model.biletModel = biletm.biletGetById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Guncelle(Bilet bilet)
        {
            BiletValidator biletValidator = new BiletValidator();
            var result = biletValidator.Validate(bilet);

            if (result.IsValid)
            {
                biletm.biletGuncelle(bilet);
                return RedirectToAction("Index");
            }
            else
            {
                BiletSeansKullaniciModel model = new BiletSeansKullaniciModel();
                model.seansModel = seansm.seansListele();
                model.kullaniciModel = kullanicim.kullaniciListele();
                model.biletModel = bilet;

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(model);
            }
        }
    }
}