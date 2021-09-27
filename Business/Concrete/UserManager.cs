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
                return new ErrorResult(Messages.UserIsNotInvalid);
            }
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            if (user.UserId >= 1)
            {
                _userDal.Delete(user);
                return new SuccessResult(Messages.UserDeleted);
            }
            else
            {
                return new ErrorResult(Messages.UserIsNotAvailable);
            }
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetUsersByUserId(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(b => b.UserId == userId));

        }

        public IResult Update(User user)
        {
            if (user.UserId >= 1)
            {
                _userDal.Update(user);
                return new SuccessResult(Messages.UserUpdated);
            }
            else
            {
                return new ErrorResult(Messages.UserIsNotAvailable);
            }
        }
    }
}
