using Business.Abstract;
using Core.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager:IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            if(brand==null)
            {
                return new ErrorResult("Marka Eklenemedi");
                
            }
            _brandDal.Add(brand);
            return new SuccessResult("Marka Eklendi");
        }

        public IResult Delete(Brand brand)
        {
            if(brand==null)
            {
                return new ErrorResult("Marka Silinemedi");
                
            }
            _brandDal.Delete(brand);
            return new SuccessResult("Marka Silindi");

        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), "Markalar Listelendi");
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(p => p.BrandId == id), "Marka filtrelendi");
        }

        public IResult Update(Brand brand)
        {
            if(brand==null)
            {
                return new ErrorResult("Marka güncellenemedi");  
            }
            _brandDal.Update(brand);
            return new SuccessResult("Marka güncellendi");

        }
    }
}
