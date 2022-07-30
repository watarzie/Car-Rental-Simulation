using Business.Abstract;
using Business.Constants;
using Core.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public IResult Add(Car car)
        {
            if(car.Descriptions.Length>2 && car.DailyPrice>0)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }
            
            return new ErrorResult(Messages.CarNameInValid);
            
        }

        public IResult Delete(Car car)
        {
            if(car.CarId==1)
            {
                _carDal.Delete(car);
                return new SuccessResult(Messages.CarDeleted);
            }
            
            return new ErrorResult(Messages.CarNotDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<Car> GetById(int id)
        {
            if(id==2)
            {
                return new SuccessDataResult<Car>(_carDal.Get(p => p.CarId == id));
            }
            return new ErrorDataResult<Car>(Messages.CarGetById);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            if(brandId==2)
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == brandId));
            }
            return new ErrorDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == brandId),Messages.CarGetByBrandId);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == colorId));
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetail()
        {
            return new SuccessDataResult<List<CarDetailDto>> (_carDal.GetCarsDetail());
        }

        public IResult Update(Car car)
        {
            if(car.CarId==1)
            {
                _carDal.Update(car);
                return new SuccessResult(Messages.CarUpdated);
            }
            
            
            return new ErrorResult(Messages.CarNotUpdated);
        }
    }
}
