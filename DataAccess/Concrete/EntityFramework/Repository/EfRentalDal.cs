using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Repository
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapSqlServerContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<RentalDetailDto, bool>> filter = null)
        {
            using (ReCapSqlServerContext context = new ReCapSqlServerContext())
            {
                var result = from r in context.Rentals
                             join cs in context.Customers
                             on r.CustomerId equals cs.CustomerId
                             join u in context.Users
                             on cs.UserId equals u.Id
                             join c in context.Cars
                             on r.Id equals c.Id
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             select new RentalDetailDto
                             {
                                 Id = c.Id,
                                 BrandId = b.BrandId,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 BrandName = b.BrandName,
                                 CompanyName = cs.CompanyName,
                                 DailyPrice = c.DailyPrice,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 ModelYear = c.ModelYear

                             };

                return result.ToList();
            }
        }
    }
}
    
