﻿using Business.Abstract;
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
        IColorDal colorDal1;

        public ColorManager(IColorDal colorDal)
        {
            colorDal1 = colorDal;
        }

        public IResult Add(Color color)
        {
            if (color.ColorName.Length < 3)
            {
                return new ErrorResult(Messages.ColorIsNotInvalid);
            }
            colorDal1.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color color)
        {

            if (color.ColorId >= 1)
            {
                colorDal1.Delete(color);
                return new SuccessResult(Messages.ColorDeleted);
            }
            else
            {
                return new ErrorResult(Messages.ColorIsNotAvailable);
            }

        }

        public IResult Update(Color color)
        {
            if (color.ColorId >= 1)
            {
                colorDal1.Update(color);
                return new SuccessResult(Messages.ColorUpdated);
            }
            else
            {
                return new ErrorResult(Messages.ColorIsNotAvailable);
            }

        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(colorDal1.GetAll());
        }

        public IDataResult<Color> GetById(int colorId)
        {
            return new SuccessDataResult<Color>(colorDal1.Get(c => c.ColorId == colorId));
        }



    }
}