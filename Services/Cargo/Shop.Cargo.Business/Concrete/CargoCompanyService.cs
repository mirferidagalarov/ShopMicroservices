using Shop.Cargo.Business.Abstract;
using Shop.DataAccess.Abstract;
using Shop.Entities.Concrete;

namespace Shop.Cargo.Business.Concrete
{
    public class CargoCompanyService : ICargoCompanyService
    {
        private readonly ICargoCompanyDal _cargoCompanyDal;
        public CargoCompanyService(ICargoCompanyDal cargoCompanyDal)
        {
            _cargoCompanyDal = cargoCompanyDal; 
        }
        public void TAdd(CargoCompany entity)
        {
           _cargoCompanyDal.Add(entity);    
        }

        public void TDelete(int id)
        {
           _cargoCompanyDal.Delete(id); 
        }

        public List<CargoCompany> TGetAll()
        {
           return  _cargoCompanyDal.GetAll();
        }

        public CargoCompany TGetById(int id)
        {
           return _cargoCompanyDal.GetById(id);
        }

        public void TUpdate(CargoCompany entity)
        {
           _cargoCompanyDal.Update(entity);
        }
    }
}
