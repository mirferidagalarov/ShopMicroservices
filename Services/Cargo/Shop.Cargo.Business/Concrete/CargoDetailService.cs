using Shop.Cargo.Business.Abstract;
using Shop.DataAccess.Abstract;
using Shop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Cargo.Business.Concrete
{
    public class CargoDetailService : ICargoDetailService
    {
        private readonly ICargoDetailDal _cargoDetailDal;
        public CargoDetailService(ICargoDetailDal cargoDetailDal)
        {
            _cargoDetailDal = cargoDetailDal;
        }
        public void TAdd(CargoDetail entity)
        {
            _cargoDetailDal.Add(entity);    
        }

        public void TDelete(int id)
        {
           _cargoDetailDal.Delete(id);  
        }

        public List<CargoDetail> TGetAll()
        {
           return _cargoDetailDal.GetAll(); 
        }

        public CargoDetail TGetById(int id)
        {
            return _cargoDetailDal.GetById(id); 
        }

        public void TUpdate(CargoDetail entity)
        {
            _cargoDetailDal.Update(entity); 
        }
    }
}
