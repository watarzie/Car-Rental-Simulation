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
    public class ColorManager:IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            if(color!=null)
            {
                _colorDal.Add(color);
                return new SuccessResult("Renk eklendi");
            }
            return new ErrorResult("Renk eklenemedi");
            
        }

        public IResult Delete(Color color)
        {
            if(color!=null)
            {
                _colorDal.Delete(color);
                return new SuccessResult("renk silindi");
                
            }
            return new ErrorResult("renk silinemedi");
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>( _colorDal.Get(p => p.ColorId == id));
        }

        public IResult Update(Color color)
        {
            if(color!=null)
            {
                _colorDal.Update(color);
                return new SuccessResult("Renk güncellendi");
            }
            return new ErrorResult("Renk Güncellenemedi");
            
        }
    }
}
