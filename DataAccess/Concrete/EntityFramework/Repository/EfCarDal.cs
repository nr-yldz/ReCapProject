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
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapSqlServerContext context = new ReCapSqlServerContext())
            {
                var result = from c in context.Cars
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join im in context.CarImages 
                             on c.Id equals im.CarId
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 ColorName = co.ColorName,
                                 BrandName = b.BrandName,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 Descriptions = c.Descriptions,
                                 Date = im.Date,
                                 ImagePath = im.ImagePath,
                                 ImageId = im.Id,
                                 

                             };
                return result.ToList();
            }
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            using (ReCapSqlServerContext context = new ReCapSqlServerContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             where c.BrandId == brandId
                             select c;

                return result.ToList();
            }
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            using (ReCapSqlServerContext context = new ReCapSqlServerContext())
            {
                var result = from c in context.Cars
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             where c.ColorId == colorId
                             select c;

                return result.ToList();
            }
        }
        public List<CarDetailDto> GetCarDetailsByBrandAndColor(int brandId, int colorId)
        {
            using (ReCapSqlServerContext context = new ReCapSqlServerContext())
            {

                var result = (from c in context.Cars.Where
                        (car => car.BrandId == brandId && car.ColorId == colorId)
                              join b in context.Brands 
                              on c.BrandId equals b.BrandId
                              join co in context.Colors 
                              on c.ColorId equals co.ColorId
                              join im in context.CarImages 
                              on c.Id equals im.CarId
                              select new CarDetailDto
                              {
                                  Id = c.Id,
                                  BrandName = b.BrandName,
                                  ColorName = co.ColorName,
                                  DailyPrice = c.DailyPrice,
                                  ImagePath = im.ImagePath,
                                  ModelYear = c.ModelYear,
                                  Descriptions = c.Descriptions,
                                  Date = im.Date,
                                  ImageId = im.Id,

                              }).ToList();
                return result.GroupBy(p => p.Id)
                    .Select(p => p.FirstOrDefault()).ToList(); ;
            }
        }

        public List<CarDetailDto> GetCarDetailById(int id)
        {
            using (ReCapSqlServerContext context = new ReCapSqlServerContext())
            {
                var result = from c in context.Cars
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join im in context.CarImages 
                             on c.Id equals im.CarId
                             where c.Id == id
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 ImagePath = im.ImagePath,
                                 ModelYear = c.ModelYear,
                                 Descriptions = c.Descriptions,
                                 Date = im.Date,
                                 ImageId = im.Id,
                             };
                              return result.ToList();
            }
        }
    }
}

