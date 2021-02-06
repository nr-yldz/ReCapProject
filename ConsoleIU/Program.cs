using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleIU
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + " " + car.Description + " " + car.DailyPrice);
            }
            

            brandManager.Add(new Brand { BrandId = 3, BrandName = "Mazda" });
            colorManager.Add(new Color { ColorId = 1, ColorName = "Pembe" });
        }
    }
}
