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
    public class BiletManager : IBiletServis
    {
        IBiletDal biletDal;

        public BiletManager(IBiletDal biletDal)
        {
            this.biletDal = biletDal;
        }
        public void biletEkle(Bilet bilet)
        {
            biletDal.insert(bilet);
        }

        public Bilet biletGetById(int id)
        {
            return biletDal.get(x => x.biletId == id);
        }

        public void biletGuncelle(Bilet bilet)
        {
            biletDal.update(bilet);
        }

        public List<Bilet> biletListele()
        {
            return biletDal.list();
        }

        public void biletSil(Bilet bilet)
        {
            biletDal.delete(bilet);
        }
    }
}
