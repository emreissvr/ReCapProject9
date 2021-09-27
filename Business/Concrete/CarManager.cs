
﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {

        ICarDal carDal1;

        public CarManager(ICarDal ıcarDal)
        {
            carDal1 = ıcarDal;
        }

        public IResult Add(Car car)
        {
            if (car.Description.Length < 2 )
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            carDal1.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }



        public IResult Delete(Car car)
        {
            if(car.CarId >= 1)
            {
                carDal1.Delete(car);
                return new SuccessResult(Messages.CarDeleted);
            }
            else
            {
                return new ErrorResult(Messages.CarIsNotAvailable);
            }

        }

      

        public IResult Update(Car car)
        {
            if(car.CarId >= 1)
            {
                carDal1.Update(car);
                return new SuccessResult(Messages.CarUpdated);
            }
            else
            {
                return new ErrorResult(Messages.CarIsNotAvailable);
            }
        }


        // business ın bildiği tek şey ICarDal'dır.

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Car>>(carDal1.GetAll(), Messages.CarsListed);
        }


        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(carDal1.GetAll(b => b.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(carDal1.GetAll(b => b.ColorId == colorId)); ;

        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(carDal1.GetCarDetails());
        }

        
    }
}