using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Repository
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapSqlServerContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapSqlServerContext context = new ReCapSqlServerContext())
            {
                var result = from c in context.Cars
                             join r in context.Rentals
                             on c.Id equals r.Id
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cstmr in context.Customers
                             on r.CustomerId equals cstmr.CustomerId
                             join u in context.Users
                             on cstmr.CustomerId equals u.Id
                             select new RentalDetailDto
                             {
                                 CarId = r.RentalId,
                                 CarName = b.BrandName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 CompanyName = cstmr.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
