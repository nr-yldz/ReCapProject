using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Repository
{
    public class EfUserDal: EfEntityRepositoryBase<User , ReCapSqlServerContext>, IUserDal
    {
    }
}
