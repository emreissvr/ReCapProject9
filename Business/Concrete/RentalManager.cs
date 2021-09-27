using Business.Abstract;
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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            if ((_rentalDal.Get(p => p.CarId == rental.CarId)) == null)
            {
                // araba kiralanmamışsa
                _rentalDal.Add(rental);
                return new ErrorResult(Messages.CarIsNotReturn);
            }
            else // araba kiralanmışsa
            {
                foreach (var rentallist in _rentalDal.GetAll())
                {
                    if (rentallist.CarId == rental.CarId)
                    {
                        if(rentallist.ReturnDate != null)
                        {
                            // araba daha önce kiralanmışsa ama geri verilmişse 
                            _rentalDal.Add(rental);
                            return new SuccessResult(Messages.RentalAdded);
                        }
                    }
                }
                // kiralanıp geri verilmemişse 
                return new ErrorResult(Messages.CarIsNotReturn);


            }
           
        }

        public IResult Delete(Rental rental)
        {
            if (rental.RentalId >= 1)
            {
                _rentalDal.Delete(rental);
                return new SuccessResult(Messages.RentalDeleted);
            }
            else
            {
                return new ErrorResult(Messages.RentalIsNotAvailable);
            }
        }

        public IResult Update(Rental rental)
        {
            if (rental.RentalId >= 1)
            {
                _rentalDal.Update(rental);
                return new SuccessResult(Messages.RentalUpdated);
            }
            else
            {
                return new ErrorResult(Messages.RentalIsNotAvailable);
            }
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetRentalsByRentalId(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(b => b.RentalId == rentalId));

        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.RentalDetails(), "Listelendi");
        }
    }
}
