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
            _cars = new List<Car>() {
                new Car { Id=1, BrandId=1, CarClassId=1, ColourId=1, DailyPrice=100, ModelYear=2015, Description="1 no lu araç", Title="1 no lu arac"},
                new Car { Id=2, BrandId=2, CarClassId=2, ColourId=3, DailyPrice=120, ModelYear=2014, Description="2 no lu araç", Title="2 no lu arac"},
                new Car { Id=3, BrandId=3, CarClassId=2, ColourId=4, DailyPrice=400, ModelYear=2017, Description="3 no lu araç", Title="3 no lu arac"},
                new Car { Id=4, BrandId=4, CarClassId=3, ColourId=2, DailyPrice=350, ModelYear=2020, Description="4 no lu araç", Title="4 no lu arac"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.Id == id).ToList();

        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.CarClassId = car.CarClassId;
            carToUpdate.ColourId = car.ColourId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Title = car.Title;

        }
    }
}
