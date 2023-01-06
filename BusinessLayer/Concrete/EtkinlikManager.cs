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
    public class EtkinlikManager : IEtkinlikServis
    {
        IEtkinlikDal etkinlikDal;

        public EtkinlikManager(IEtkinlikDal etkinlikDal)
        {
            this.etkinlikDal = etkinlikDal;
        }
        public void etkinlikEkle(Etkinlik etkinlik)
        {
            etkinlikDal.insert(etkinlik);
        }

        public Etkinlik etkinlikGetById(int id)
        {
            return etkinlikDal.get(x => x.etkinlikId == id);
        }

        public Etkinlik etkinlikGetByName(string ad)
        {
            return etkinlikDal.get(x => x.etkinlikAd == ad);
        }

        public void etkinlikGuncelle(Etkinlik etkinlik)
        {
            etkinlikDal.update(etkinlik);
        }

        public List<Etkinlik> etkinlikListele()
        {
            return etkinlikDal.list();
        }

        public void etkinlikSil(Etkinlik etkinlik)
        {
            etkinlikDal.delete(etkinlik);
        }
    }
}
