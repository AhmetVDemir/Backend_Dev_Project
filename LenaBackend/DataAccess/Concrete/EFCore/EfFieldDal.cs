﻿using Core.DataAccess.EF;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EFCore
{
    public class EfFieldDal : EFEntityRepositoryBase<Field,BackendDevContext>,IFieldDal
    {
    }
}
