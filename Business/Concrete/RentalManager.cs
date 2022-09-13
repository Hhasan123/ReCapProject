using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public IResult Add(Rental rental)
        {
            if (rental.RentDate > rental.ReturnDate)
            {
                return new ErrorResult(MessageAboutRentals.DateInvalid);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(MessageAboutRentals.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            if (rental.RentId == _rentalDal.Get(r => r.RentId == rental.RentId).RentId)
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
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentId == id), MessageAboutRentals.RentalGetted);
        }

        public IResult Update(Rental rental)
        {
            if (rental.RentDate > rental.ReturnDate)
            {
                return new ErrorResult(MessageAboutRentals.DateInvalid);
            }
            _rentalDal.Update(rental);
            return new SuccessResult(MessageAboutRentals.RentalUpdated);
        }
    }
}
