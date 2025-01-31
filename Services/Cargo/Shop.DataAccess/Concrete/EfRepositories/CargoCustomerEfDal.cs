using Shop.DataAccess.Abstract;
using Shop.DataAccess.Concrete.DataContext;
using Shop.DataAccess.Concrete.Repositories;
using Shop.Entities.Concrete;

namespace Shop.DataAccess.Concrete.EfRepositories
{
    public class CargoCustomerEfDal:GenericRepository<CargoCustomer>,ICargoCustomerDal 
    {
        private readonly CargoContext _cargoContext;
        public CargoCustomerEfDal(CargoContext cargoContext):base(cargoContext) 
        {
            _cargoContext = cargoContext;
        }
    }
}
