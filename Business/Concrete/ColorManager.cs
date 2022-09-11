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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            if (color.ColorName.Length < 2)
            {
                return new ErrorDataResult<Color>(MessagesAboutColors.ColorNameInvalid);
            }
            _colorDal.Add(color);
            return new SuccessResult(MessagesAboutColors.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(MessagesAboutColors.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), MessagesAboutColors.ColorsListed); ;
        }

        public IDataResult<Color> GetById(int id)
        {
            _colorDal.Get(c => c.ColorId == id);
            return new SuccessDataResult<Color>(MessagesAboutColors.ColorGetted);
        }

        public IResult Update(Color color)
        {
            return new SuccessResult(MessagesAboutColors.ColorUpdated);
        }
    }
}
