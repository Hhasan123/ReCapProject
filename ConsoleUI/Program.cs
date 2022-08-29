using Business.Concrete;
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
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Title);
            }
            Console.WriteLine("Özellikleri getirilecek aracın id sini giriniz. =>");
            foreach(var car in carManager.GetById(Convert.ToInt32(Console.ReadLine())))
            {
                Console.WriteLine("Aracın Markası =>"+ car.BrandId);
                Console.WriteLine("Aracın Sınıfı =>" + car.CarClassId);
                Console.WriteLine("Aracın Rengi =>" + car.ColourId);
                Console.WriteLine("Aracın Günlük Kira Ücreti =>" + car.DailyPrice);
                Console.WriteLine("Aracın Açıklaması =>" + car.Description);
                Console.WriteLine("Aracın Model Yılı =>" + car.ModelYear);

            }
        }
    }
}
