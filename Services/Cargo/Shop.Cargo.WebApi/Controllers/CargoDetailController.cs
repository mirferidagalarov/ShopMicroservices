using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Cargo.Business.Abstract;
using Shop.DTOs.CargoDetailDTOs;
using Shop.Entities.Concrete;

namespace Shop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;
        public CargoDetailController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = _cargoDetailService.TGetAll();
            return Ok(data);
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var data = _cargoDetailService.TGetById(id);
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Add(CargoDetailAddDTO cargoDetailAddDTO)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
                BarCode = cargoDetailAddDTO.BarCode,
                CargoCompanyId = cargoDetailAddDTO.CargoCompanyId,
                ReceiverCustomer = cargoDetailAddDTO.ReceiverCustomer,
                SenderCustomer = cargoDetailAddDTO.SenderCustomer,
            };
            _cargoDetailService.TAdd(cargoDetail);
            return Ok("data added  successfuly");
        }

        [HttpPut]
        public IActionResult Update(CargoDetailUpdateDTO cargoDetailUpdateDTO)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
                Id = cargoDetailUpdateDTO.Id,
                BarCode = cargoDetailUpdateDTO.BarCode,
                CargoCompanyId = cargoDetailUpdateDTO.CargoCompanyId,
                ReceiverCustomer = cargoDetailUpdateDTO.ReceiverCustomer,
                SenderCustomer = cargoDetailUpdateDTO.SenderCustomer,
            };
            _cargoDetailService.TUpdate(cargoDetail);
            return Ok("data update successfuly");
        }

        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            _cargoDetailService.TDelete(id);
            return Ok("data deleted successfuly");
        }
    }
}
