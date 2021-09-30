﻿using Business.Abstract;
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
    public class BrandManager : IBrandService
    {
        IBrandDal brandDal1;

        public BrandManager(IBrandDal brandDal)
        {
            brandDal1 = brandDal;
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            //if (brand.BrandName.Length <= 3 )
            //{
            //    return new ErrorResult(Messages.BrandIsNotInvalid);
            //}

            brandDal1.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(Brand brand)
        {

            if (brand.BrandId >= 1)
            {
                brandDal1.Delete(brand);
                return new SuccessResult(Messages.BrandDeleted);
            }
            else
            {
                return new ErrorResult(Messages.BrandIsNotAvailable);
            }

        }

        public IResult Update(Brand brand)
        {
            if (brand.BrandId >= 1)
            {
                brandDal1.Update(brand);
                return new SuccessResult(Messages.BrandUpdated);
            }
            else
            {
                return new ErrorResult(Messages.BrandIsNotAvailable);
            }

        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(brandDal1.GetAll());
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>(brandDal1.Get(b => b.BrandId == brandId ));
        }

        

       
    }
}
