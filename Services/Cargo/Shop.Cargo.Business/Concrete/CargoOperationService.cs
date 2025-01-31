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
    public class CargoOperationService : ICargoOperationService
    {
        private readonly ICargoOperationDal _cargoOperationDal;
        public CargoOperationService(ICargoOperationDal  cargoOperationDal)
        {
            _cargoOperationDal = cargoOperationDal;   
        }
        public void TAdd(CargoOperation entity)
        {
            _cargoOperationDal.Add(entity);
        }

        public void TDelete(int id)
        {
            _cargoOperationDal.Delete(id);  
        }

        public List<CargoOperation> TGetAll()
        {
            return _cargoOperationDal.GetAll(); 
        }

        public CargoOperation TGetById(int id)
        {
           return _cargoOperationDal.GetById(id);   
        }

        public void TUpdate(CargoOperation entity)
        {
            _cargoOperationDal.Update(entity);
        }
    }
}
