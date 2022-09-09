using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {

        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice >= max);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }

        public void Add(Car car)
        {
            if (car.DailyPrice <= 0 || car.Name.Length < 2)
            {
                Console.WriteLine("Araç kiralama ücreti 0 dan büyük olmalı ve araç ismi minimum 2 karakterli olmalıdır.");
            }
            else
            {
                _carDal.Add(car);
            }

        }

        public void Update(Car car)
        {
            if (car.DailyPrice <= 0 || car.Name.Length < 2)
            {
                Console.WriteLine("Araç kiralama ücreti 0 dan büyük olmalı ve araç ismi minimum 2 karakterli olmalıdır.");
            }
            else
            {
                _carDal.Update(car);
            }

        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }
    }
}
