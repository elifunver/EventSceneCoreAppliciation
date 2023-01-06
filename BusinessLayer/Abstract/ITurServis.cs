using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ITurServis
    {
        void turEkle(Tur tur);
        void turSil(Tur tur);
        void turGuncelle(Tur tur);
        List<Tur> turListele();
        Tur turGetById(int id);
        Tur turGetByName(string ad);
    }
}
