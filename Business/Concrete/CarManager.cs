using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),MessagesAboutCar.CarsListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice >= max));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }

        public IResult Add(Car car)
        {
            if (car.Name.Length < 2)
            {
                return new ErrorResult(MessagesAboutCar.CarNameInvalid);
            }
            else if(car.DailyPrice <= 0)
            {
                return new ErrorResult(MessagesAboutCar.CarDailyPriceInvalid);
            }
            _carDal.Add(car);
            return new SuccessResult(MessagesAboutCar.CarAdded);

            }

        public IResult Update(Car car)
        {
            if (car.Name.Length < 2)
            {
                return new ErrorResult(MessagesAboutCar.CarNameInvalid);
            }
            else if(car.DailyPrice <= 0)
            {
                return new ErrorResult(MessagesAboutCar.CarDailyPriceInvalid);
            }
            _carDal.Update(car);
            return new SuccessResult(MessagesAboutCar.CarUpdated);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(MessagesAboutCar.CarDeleted);   
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),MessagesAboutCar.CarsListed); 
        }
    }
}
