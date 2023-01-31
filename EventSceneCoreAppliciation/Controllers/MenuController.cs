﻿using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer;
using EventSceneCoreAppliciation.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventSceneCoreAppliciation.Controllers
{
    public class MenuController : Controller
    {
        MenuManager menuManager = new MenuManager(new EfMenuRepository());

        public IActionResult Index()
        {
            var menus = menuManager.menuListele();
            return View(menus);
        }

        public IActionResult sil(int id)
        {
            var menu = menuManager.menuGetById(id);
            menu.silindi = true;
            menuManager.menuGuncelle(menu);
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult guncelle(int id)
        {
            var menu = menuManager.menuGetById(id);
            var menulist = menuManager.menuListele();
            MenuParentListModel menuParentListModel = new MenuParentListModel();
            menuParentListModel.menuListModel = menulist;
            menuParentListModel.menuModel = menu;
            return View(menuParentListModel);
        }

        [HttpPost]
        public IActionResult guncelle(Menu menu)
        {
            menuManager.menuGuncelle(menu);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult ekle()
        {

            var menulist = menuManager.menuListele();
            MenuParentListModel menuParentListModel = new MenuParentListModel();
            menuParentListModel.menuListModel = menulist;
            menuParentListModel.menuModel = new Menu();
            return View(menuParentListModel);
        }

        [HttpPost]
        public IActionResult ekle(Menu menu)
        {
            var sonuc = menuManager.menuGetBySeoUrl(menu.seoUrl);
            if (sonuc != null)
            {
                var menulist = menuManager.menuListele();
                MenuParentListModel menuParentListModel = new MenuParentListModel();
                menuParentListModel.menuListModel = menulist;
                menuParentListModel.menuModel = new Menu();
                return View(menuParentListModel);
            }
            menuManager.menuEkle(menu);
            return RedirectToAction("Index");
        }
    }
}