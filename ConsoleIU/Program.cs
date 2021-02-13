using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //ColorManager colorManager = new ColorManager(new EfColorDal());
           
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.DailyPrice+" "+car.BrandName);
            }


           Console.WriteLine("------------------------------------");

            //foreach (var brand in brandManager.GetAll())
            // {
            //     Console.WriteLine(brand.BrandId + "  " + brand.BrandName);
            // }

            // Console.WriteLine("------------------------------------");

            // foreach (var color in colorManager.GetAll())
            // {
            //    Console.WriteLine(color.ColorId + color.ColorName);
            //}
            //colorManager.Add(new Color {ColorName= " Pink "});
            brandManager.Add(new Brand { BrandName = "Crysler" });
                
        }
    }
}