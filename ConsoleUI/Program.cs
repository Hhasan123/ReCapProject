using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManagerTest();
            //BrandManagerTest();
            //ColorManagerTest();
        }

        private static void ColorManagerTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();
            foreach (var color in result.Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void BrandManagerTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAll();
            foreach (var brand in result.Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarManagerTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //var result = carManager.GetAll();
            //Console.WriteLine(result.Message);
            //foreach (var car in result.Data)
            //{
            //    //Console.WriteLine(result.Message);
            //    Console.WriteLine(car.Name);

            //}

            foreach (var carDetails in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("Car Name = " + carDetails.CarName + "\n" +
                    "Brand = " + carDetails.BrandName + "\n" +
                    "Color = " + carDetails.CarName + "\n" +
                    "Dailiy Price = " + carDetails.DailyPrice);
                Console.WriteLine("-------------------");
            }
        }
    }
}
