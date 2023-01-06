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
    public class SeansManager : ISeansServis
    {
        ISeansDal seansDal;
        public SeansManager(ISeansDal seansDal)
        {
            this.seansDal = seansDal;
        }
        public void seansEkle(Seans seans)
        {
            seansDal.insert(seans);
        }

        public Seans seansGetById(int id)
        {
            return seansDal.get(x => x.seansId == id);
        }


        public void seansGuncelle(Seans seans)
        {
            seansDal.update(seans);
        }

        public List<Seans> seansListele()
        {
            return seansDal.list();
        }

        public void seansSil(Seans seans)
        {
            seansDal.delete(seans);
        }
    }
}
