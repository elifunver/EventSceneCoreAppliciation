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
    public class TurManager : ITurServis
    {
        ITurDal turDal;
        public TurManager(ITurDal turDal)
        {
            this.turDal = turDal;
        }
        public void turEkle(Tur tur)
        {
            turDal.insert(tur);
        }

        public Tur turGetirById(int id)
        {
            return turDal.get(x => x.turId == id);
        }

        public Tur turGetirByName(string ad)
        {
            return turDal.get(x => x.turAd == ad);
        }

        public void turGuncelle(Tur tur)
        {
            turDal.update(tur);
        }

        public List<Tur> turListele()
        {
            return turDal.list();
        }

        public void turSil(Tur tur)
        {
            turDal.delete(tur);
        }
    }
}
