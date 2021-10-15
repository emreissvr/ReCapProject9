using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Entities.Concrete;
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
            //if (user.FirstName.Length <= 3)
            //{
            //    return new ErrorResult(Messages.UserIsNotInvalid);
            //}
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            if (user.Id >= 1)
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
            return new SuccessDataResult<User>(_userDal.Get(b => b.Id == userId));

        }

        public IResult Update(User user)
        {
            if (user.Id >= 1)
            {
                _userDal.Update(user);
                return new SuccessResult(Messages.UserUpdated);
            }
            else
            {
                return new ErrorResult(Messages.UserIsNotAvailable);
            }
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }
    }
}
