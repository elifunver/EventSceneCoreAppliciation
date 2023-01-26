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
        SeyirciManager seyircim = new SeyirciManager(new EfSeyirciRepository());
        public IActionResult Index()
        {
            var biletler = biletm.biletListele();
            return View(biletler);
        }
        [HttpGet]
        public IActionResult Ekle()
        {
            BiletSeansSeyirciModel model = new BiletSeansSeyirciModel();
            model.seansModel = seansm.seansListele();
            model.seyirciModel = seyircim.seyirciListele();
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
                BiletSeansSeyirciModel model = new BiletSeansSeyirciModel();
                model.seansModel = seansm.seansListele();
                model.seyirciModel = seyircim.seyirciListele();
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
            BiletSeansSeyirciModel model = new BiletSeansSeyirciModel();
            model.seansModel=seansm.seansListele();
            model.seyirciModel=seyircim.seyirciListele();
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
                BiletSeansSeyirciModel model = new BiletSeansSeyirciModel();
                model.seansModel = seansm.seansListele();
                model.seyirciModel = seyircim.seyirciListele();
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