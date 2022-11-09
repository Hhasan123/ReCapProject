using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult(MessageAboutRentals.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            if (rental.Id == _rentalDal.Get(r => r.Id == rental.Id).Id)
            {
                _rentalDal.Delete(rental);
                return new SuccessResult(MessageAboutRentals.RentalUpdated);
            }
            return new ErrorResult(MessageAboutRentals.RentalNotFound);

        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), MessageAboutRentals.RentalsListed);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id), MessageAboutRentals.RentalGetted);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IDataResult<List<RentalDto>> GetRentalDto()
        {
            return new SuccessDataResult<List<RentalDto>>(_rentalDal.GetRentalDto(), MessageAboutRentals.RentalGetted);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(MessageAboutRentals.RentalUpdated);
        }
    }
}
