using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISeyirciServis
    {
        void seyirciEkle(Seyirci seyirci);
        void seyirciSil(Seyirci seyirci);
        void seyirciGuncelle(Seyirci seyirci);
        List<Seyirci> seyirciListele();
        Seyirci seyirciGetById(int id);
        Seyirci seyirciGetByName(string ad);
    }
}
