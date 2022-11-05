using Business.Abstract;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessDataResult<User>(MessagesAboutUser.UserAdded);

        }

        public IResult Delete(User user)
        {
            if (user.Id == _userDal.Get(u => u.Id == user.Id).Id)
            {
                _userDal.Delete(user);
                return new SuccessDataResult<User>(MessagesAboutUser.UserDeleted);
            }
            return new ErrorResult(MessagesAboutUser.UserNotFound);
        }

        public IDataResult<List<User>> GetAll()
        {

            return new SuccessDataResult<List<User>>(_userDal.GetAll(), MessagesAboutUser.UserListed);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id), MessagesAboutUser.UserGetted);
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessDataResult<User>(MessagesAboutUser.UserUpdated);
        }
    }
}
