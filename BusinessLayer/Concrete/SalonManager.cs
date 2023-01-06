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
    public class SalonManager : ISalonServis
    {
        ISalonDal salonDal;
        public SalonManager(ISalonDal salonDal)
        {
            this.salonDal = salonDal;
        }
        public void salonEkle(Salon salon)
        {
            salonDal.insert(salon);
        }

        public Salon salonGetById(int id)
        {
            return salonDal.get(x => x.salonId == id);
        }

        public Salon salonGetByName(string ad)
        {
            return salonDal.get(x => x.salonAd == ad);
        }

        public void salonGuncelle(Salon salon)
        {
            salonDal.update(salon);
        }

        public List<Salon> salonListele()
        {
            return salonDal.list();
        }

        public void salonSil(Salon salon)
        {
            salonDal.delete(salon);
        }
    }
}
