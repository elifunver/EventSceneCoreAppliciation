using BusinessLayer.Concrete;
using BusinessLayer.Validaitons;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;

namespace EventSceneCoreAppliciation.Controllers
{
    public class BiletController : Controller
    {
        BiletManager biletm = new BiletManager(new EfBiletRepository());
        SeansManager seansManager = new SeansManager(new EfSeansRepository());
        SeyirciManager seyirciManager = new SeyirciManager(new EfSeyirciRepository());
        public IActionResult Index()
        {
            var biletler = biletm.biletListele();
            return View(biletler);
        }
        [HttpGet]
        public IActionResult Ekle()
        {
            BiletSeansEtkinlikSeyirciModel biletSeansEtkinlikSeyirciModel = new BiletSeansEtkinlikSeyirciModel();
            biletSeansEtkinlikSeyirciModel.seansModel = seansManager.seansListele();
            biletSeansEtkinlikSeyirciModel.seyirciModel = seyirciManager.seyirciListele();
            biletSeansEtkinlikSeyirciModel.biletModel = new Bilet();
            return View(biletSeansEtkinlikSeyirciModel);
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
                BiletSeansEtkinlikSeyirciModel BiletSeansEtkinlikSeyirciModel biletSeansEtkinlikSeyirciModel = new BiletSeansEtkinlikSeyirciModel();
                biletSeansEtkinlikSeyirciModel.seansModel = seansManager.seansListele();
                biletSeansEtkinlikSeyirciModel.seyirciModel = seyirciManager.seyirciListele();
                biletSeansEtkinlikSeyirciModel.biletModel = bilet;
                return View(biletSeansEtkinlikSeyirciModel);
            }
        }
        public IActionResult Sil(int id)
        {
            Bilet bilet = biletm.biletGetById(id);
            bilet.silindi = true;
            biletm.biletGuncelle(bilet);
            return RedirectToAction("Index");
        }
        public IActionResult Guncelle(int id)
        {
            Bilet bilet = biletm.biletGetById(id);
            return View(bilet);
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
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(bilet);
            }

        }
    }
}
