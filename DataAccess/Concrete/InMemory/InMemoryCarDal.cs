using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
            new Car{CategoryId=1, Id=1, BrandId=1, ColorId=1, DailyPrice=77, Description="Fiat Panda",   ModelYear=2010},
            new Car{CategoryId=1, Id=2, BrandId=1, ColorId=2, DailyPrice=77, Description="Fiat Panda", ModelYear=2012},
            new Car{CategoryId=1, Id=3, BrandId=2, ColorId=3, DailyPrice=82, Description="Hyundai i20",  ModelYear=2013},
            new Car{CategoryId=1, Id=4, BrandId=3, ColorId=4, DailyPrice=88, Description="Opel Astra", ModelYear=2014},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete;
            carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int Id)
        {
         return   _cars.Where(c => c.Id == Id).ToList();      
        }

        public void Update(Car car)
        {
            Car carToUpdate;
            carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.CategoryId = car.CategoryId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
