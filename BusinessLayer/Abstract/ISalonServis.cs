using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISalonServis
    {
        void salonEkle(Salon salon);
        void salonSil(Salon salon);
        void salonGuncelle(Salon salon);
        List<Salon> salonListele();
        Salon salonGetirById(int id);
        Salon salonGetirByName(string name);
    }
}
