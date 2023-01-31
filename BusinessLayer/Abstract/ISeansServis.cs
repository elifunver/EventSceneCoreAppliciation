using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISeansServis
    {
        void seansEkle(Seans seans);
        void seansSil(Seans seans);
        void seansGuncelle(Seans seans);
        List<Seans> seansListele();
        Seans seansGetById(int id);
    }
}