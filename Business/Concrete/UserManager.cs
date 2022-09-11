using Business.Abstract;
using Business.Constants.Messages;
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

        public IResult Add(User user)
        {
            if (user.FirstName.Length < 3)
            {
                return new ErrorDataResult<User>(MessagesAboutUser.UserNameInvalid);
            }
            else if (user.LastName.Length < 3)
            {
                return new ErrorDataResult<User>(MessagesAboutUser.UserSurnameInvalid);
            }
            else if (user.Password.Length < 4)
            {
                return new ErrorDataResult<User>(MessagesAboutUser.UserPasswordInvalid);
            }
            else if (user.Email.EndsWith("@gmail.com"))
            {
                _userDal.Add(user);
                return new SuccessDataResult<User>(MessagesAboutUser.UserAdded);
            }
            else
            {
                return new ErrorDataResult<User>(MessagesAboutUser.UserEmailNotAppropriate);
            }
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessDataResult<User>(MessagesAboutUser.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {

            return new SuccessDataResult<List<User>>(_userDal.GetAll(), MessagesAboutUser.UserListed);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u=>u.Id==id), MessagesAboutUser.UserGetted);
        }

        public IResult Update(User user)
        {
            if (user.FirstName.Length < 3)
            {
                return new ErrorDataResult<User>(MessagesAboutUser.UserNameInvalid);
            }
            else if (user.LastName.Length < 3)
            {
                return new ErrorDataResult<User>(MessagesAboutUser.UserSurnameInvalid);
            }
            else if (user.Password.Length < 4)
            {
                return new ErrorDataResult<User>(MessagesAboutUser.UserPasswordInvalid);
            }
            else if (user.Email.EndsWith("@gmail.com"))
            {
                _userDal.Update(user);
                return new SuccessDataResult<User>(MessagesAboutUser.UserUpdated);
            }
            else
            {
                return new ErrorDataResult<User>(MessagesAboutUser.UserEmailNotAppropriate);
            }
        }
    }
}
