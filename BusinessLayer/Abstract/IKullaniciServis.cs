using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IKullaniciServis
    {
        void kullaniciEkle(Kullanici kullanici);
        void kullaniciSil(Kullanici kullanici);
        void kullaniciGuncelle(Kullanici kullanici);
        List<Kullanici> kullaniciListele();
        Kullanici kullaniciGetById(int id);
        Kullanici kullaniciGetByName(string ad);
    }
}