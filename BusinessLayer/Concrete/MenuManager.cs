using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MenuManager : IMenuServis
    {
        IMenuDal menuDal;
        public MenuManager(IMenuDal menuDal)
        {
            this.menuDal = menuDal;
        }
        public void menuEkle(Menu menu)
        {
            menuDal.insert(menu);
        }

        public Menu menuGetById(int id)
        {
            return menuDal.get(menu => menu.menuId == id);
        }

        public Menu menuGetBySeoUrl(string seoUrl)
        {
            return menuDal.get(menu => menu.seoUrl == seoUrl);
        }

        public void menuGuncelle(Menu menu)
        {
            menuDal.update(menu);
        }

        public List<Menu> menuListele()
        {
            return menuDal.list();
        }
    }
}
