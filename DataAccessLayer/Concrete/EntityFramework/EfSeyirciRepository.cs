﻿using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    class EfSeyirciRepository : GenericRepository<Seyirci>, ISeyirciDal
    {
    }
}
