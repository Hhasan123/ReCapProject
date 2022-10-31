using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            
            ValidationTool.Validate(new BrandValidator(), brand);
            _brandDal.Add(brand);
            return new SuccessDataResult<Brand>(MessagesAboutBrand.BrandAdded);
        }

        public IResult Delete(Brand brand)
        {
            if (brand.BrandId == _brandDal.Get(c => c.BrandId == brand.BrandId).BrandId)
            {
                _brandDal.Delete(brand);
                return new SuccessResult(MessagesAboutCar.CarDeleted);
            }
            return new ErrorResult(MessagesAboutBrand.BrandNotFound);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),MessagesAboutBrand.BrandsListed );
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>( _brandDal.Get(b => b.BrandId == brandId));
        }

        public IResult Update(Brand brand)
        {
            ValidationTool.Validate(new BrandValidator(), brand);
            _brandDal.Update(brand);
            return new SuccessDataResult<Brand>(MessagesAboutBrand.BrandUpdated);
        }
    }
}
