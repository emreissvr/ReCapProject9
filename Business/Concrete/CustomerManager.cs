using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            //if (customer.CompanyName.Length <= 3)
            //{
            //    return new ErrorResult(Messages.CustomerIsNotInvalid);
            //}
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            if (customer.CustomerId >= 1)
            {
                _customerDal.Delete(customer);
                return new SuccessResult(Messages.CustomerDeleted);
            }
            else
            {
                return new ErrorResult(Messages.CustomerIsNotAvailable);
            }
        }

        public IResult Update(Customer customer)
        {
            if (customer.CustomerId >= 1)
            {
                _customerDal.Update(customer);
                return new SuccessResult(Messages.CustomerUpdated);
            }
            else
            {
                return new ErrorResult(Messages.CustomerIsNotAvailable);
            }
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<Customer> GetCustomersByCustomerId(int customerId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(b => b.CustomerId == customerId));
        }

       
    }
}
