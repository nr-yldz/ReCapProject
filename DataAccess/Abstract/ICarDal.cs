using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<Car> GetCarsByBrandId(int brandId);
        List<Car> GetCarsByColorId(int colorId);
        List<CarDetailDto> GetCarDetailById(int id);
        List<CarDetailDto> GetCarDetailsByBrandAndColor(int brandId, int colorId);
        List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null);
        
    }
}
