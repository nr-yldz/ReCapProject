using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Repository;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarManager carManager = new CarManager(new EfCarDal());
            //BrandManager brandManager = new BrandManager(new EfBrandDal());
           // ColorManager colorManager = new ColorManager(new EfColorDal());
            //UserManager userManager = new UserManager(new EfUserDal());
            //CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            //TestCarDetails(carManager);

            Console.WriteLine("------------------------------------");

            var result = rentalManager.Add(new Rental
            {
                Id = 2,
                CustomerId = 3,
                RentalId = 2,
                RentDate = new DateTime(2021, 2, 5, 11, 30, 00)
            }
                );
            Console.WriteLine(result.Message);
           

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
            // brandManager.Add(new Brand { BrandName = "Crysler" });

        }

        private static void TestCarDetails(CarManager carManager)
        {
            var result = carManager.GetCarDetails();

            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.BrandName + " " + car.ColorName);
                }


            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}