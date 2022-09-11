using Business.Abstract;
using Business.Constants;
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
            if (brand.BrandName.Length < 2)
            {
                return new ErrorDataResult<Brand>(MessagesAboutBrand.BrandNameInvalid);
            }
            _brandDal.Add(brand);
            return new SuccessDataResult<Brand>(MessagesAboutBrand.BrandAdded);
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessDataResult<Brand>(MessagesAboutBrand.BrandDeleted);
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
            if(brand.BrandName.Length<2)
            _brandDal.Update(brand);
            return new SuccessDataResult<Brand>(MessagesAboutBrand.BrandUpdated);
        }
    }
}
