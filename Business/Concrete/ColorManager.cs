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
                return new ErrorDataResult<Color>(MessagesAboutColor.ColorNameInvalid);
            }
            _colorDal.Add(color);
            return new SuccessResult(MessagesAboutColor.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            if (color.ColorId == _colorDal.Get(c => c.ColorId == color.ColorId).ColorId)
            {
                _colorDal.Delete(color);
                return new SuccessResult(MessagesAboutColor.ColorDeleted);
            }
            return new ErrorResult(MessagesAboutColor.ColorNotFound);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), MessagesAboutColor.ColorsListed); ;
        }

        public IDataResult<Color> GetById(int id)
        {
            _colorDal.Get(c => c.ColorId == id);
            return new SuccessDataResult<Color>(MessagesAboutColor.ColorGetted);
        }

        public IResult Update(Color color)
        {
            return new SuccessResult(MessagesAboutColor.ColorUpdated);
        }
    }
}
