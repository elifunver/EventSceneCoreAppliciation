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
    public class SeyirciManager : ISeyirciServis
    {
        ISeyirciDal seyirciDal;
        public SeyirciManager(ISeyirciDal seyirciDal)
        {
            this.seyirciDal = seyirciDal;
        }
        public void seyirciEkle(Seyirci seyirci)
        {
            seyirciDal.insert(seyirci);
        }

        public Seyirci seyirciGetirById(int id)
        {
            return seyirciDal.get(x => x.seyirciId == id);
        }

        public Seyirci seyirciGetirByName(string ad)
        {
            return seyirciDal.get(x => x.seyirciAd == ad);
        }

        public void seyirciGuncelle(Seyirci seyirci)
        {
            seyirciDal.update(seyirci);
        }

        public List<Seyirci> seyirciListele()
        {
            return seyirciDal.list();
        }

        public void seyirciSil(Seyirci seyirci)
        {
            seyirciDal.delete(seyirci);
        }
    }
}
