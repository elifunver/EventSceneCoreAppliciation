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
    public class KullaniciManager : IKullaniciServis
    {
        IKullaniciDal kullaniciDal;

        public KullaniciManager(IKullaniciDal kullaniciDal)
        {
            this.kullaniciDal = kullaniciDal;
        }

        public void kullaniciEkle(Kullanici kullanici)
        {
            kullaniciDal.insert(kullanici);
        }

        public Kullanici kullaniciGetById(int id)
        {
            return kullaniciDal.get(x => x.kullaniciId == id);
        }

        public Kullanici kullaniciGetByName(string ad)
        {
            return kullaniciDal.get(x => x.kullaniciAd == ad);
        }

        public void kullaniciGuncelle(Kullanici kullanici)
        {
            kullaniciDal.update(kullanici);
        }

        public List<Kullanici> kullaniciListele()
        {
            return kullaniciDal.list();
        }

        public void kullaniciSil(Kullanici kullanici)
        {
            kullaniciDal.delete(kullanici);
        }
    }
}