using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapSqlServerContext>, ICarDal
    {
       

        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapSqlServerContext context = new ReCapSqlServerContext())
            {
                var result = from c in context.Cars
                             join br in context.Brands
                             on c.BrandId equals br.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             select new CarDetailDto
                             {
                                 Id= c.Id, BrandId = br.BrandId, BrandName=br.BrandName, 
                                 ColorId=co.ColorId, ColorName=co.ColorName,DailyPrice=c.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}

