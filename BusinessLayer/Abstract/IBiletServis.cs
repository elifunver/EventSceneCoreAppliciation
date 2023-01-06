using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBiletServis
    {
        void biletEkle(Bilet bilet);
        void biletSil(Bilet bilet);
        void biletGuncelle(Bilet bilet);
        List<Bilet> biletListele();
        Bilet biletGetById(int id);
    }
}
