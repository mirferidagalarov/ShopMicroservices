using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Cargo.Business.Abstract;
using Shop.DTOs.CargoCustomerDTOs;
using Shop.Entities.Concrete;

namespace Shop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomerController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;
        public CargoCustomerController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = _cargoCustomerService.TGetAll();
            return Ok(data);
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var data = _cargoCustomerService.TGetById(id);
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Add(CargoCustomerAddDTO cargoCustomerAddDTO)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                Address = cargoCustomerAddDTO.Address,
                City = cargoCustomerAddDTO.City,
                District = cargoCustomerAddDTO.District,
                Email = cargoCustomerAddDTO.Email,
                Name = cargoCustomerAddDTO.Name,
                Phone = cargoCustomerAddDTO.Phone,
                Surname = cargoCustomerAddDTO.Surname,
            };
            _cargoCustomerService.TAdd(cargoCustomer);
            return Ok("data added  successfuly");
        }

        [HttpPut]
        public IActionResult Update(CargoCustomerUpdateDTO  cargoCustomerUpdateDTO)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                Id = cargoCustomerUpdateDTO.Id,
                Address = cargoCustomerUpdateDTO.Address,
                City = cargoCustomerUpdateDTO.City,
                District = cargoCustomerUpdateDTO.District,
                Email = cargoCustomerUpdateDTO.Email,
                Name = cargoCustomerUpdateDTO.Name,
                Phone = cargoCustomerUpdateDTO.Phone,
                Surname = cargoCustomerUpdateDTO.Surname,
            };
            _cargoCustomerService.TUpdate(cargoCustomer);
            return Ok("data update successfuly");
        }

        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            _cargoCustomerService.TDelete(id);
            return Ok("data deleted successfuly");
        }
    }
}
