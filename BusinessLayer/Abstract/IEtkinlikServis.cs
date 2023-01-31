using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IEtkinlikServis
    {
        void etkinlikEkle(Etkinlik etkinlik);
        void etkinlikSil(Etkinlik etkinlik);
        void etkinlikGuncelle(Etkinlik etkinlik);
        List<Etkinlik> etkinlikListele();
        Etkinlik etkinlikGetById(int id);
        Etkinlik etkinlikGetByName(string ad);
    }
}