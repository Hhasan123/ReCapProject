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
            //CarManagerTest();
            //BrandManagerTest();
            //ColorManagerTest();
        }

        private static void ColorManagerTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            //Buradaki ekleme işlemi hata verecektir sebebi ColorId sütununun veritabanında primary key olmasıdır.
            colorManager.Add(new Color() { ColorId = 1, ColorName = "Beyaz" });
            colorManager.Add(new Color() { ColorId = 2, ColorName = "Kırmızı" });
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void BrandManagerTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarManagerTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Name);
            }
            foreach (var carDetails in carManager.GetCarDetails())
            {
                Console.WriteLine("Car Name = " + carDetails.CarName+"\n" +
                    "Brand = " + carDetails.BrandName + "\n" +
                    "Color = " + carDetails.CarName + "\n" +
                    "Dailiy Price = " + carDetails.DailyPrice);
            }
        }
    }
}
