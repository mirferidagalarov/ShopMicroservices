using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Cargo.Business.Abstract;
using Shop.DTOs.CargoOperationDTOs;
using Shop.Entities.Concrete;

namespace Shop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;
        public CargoOperationController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = _cargoOperationService.TGetAll();
            return Ok(data);
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var data = _cargoOperationService.TGetById(id);
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Add(CargoOperationAddDTO cargoOperationAddDTO)
        {
            CargoOperation cargoOperation = new CargoOperation()
            {
                BarCode = cargoOperationAddDTO.BarCode,
                Description = cargoOperationAddDTO.Description,
                OperationDate = cargoOperationAddDTO.OperationDate,
            };
            _cargoOperationService.TAdd(cargoOperation);
            return Ok("data added  successfuly");
        }

        [HttpPut]
        public IActionResult Update(CargoOperationUpdateDTO  cargoOperationUpdateDTO)
        {
            CargoOperation cargoOperation = new CargoOperation()
            {
                 Id = cargoOperationUpdateDTO.Id,   
                BarCode = cargoOperationUpdateDTO.BarCode,
                Description = cargoOperationUpdateDTO.Description,
                OperationDate = cargoOperationUpdateDTO.OperationDate,
            };
            _cargoOperationService.TUpdate(cargoOperation);
            return Ok("data update successfuly");
        }

        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            _cargoOperationService.TDelete(id);
            return Ok("data deleted successfuly");
        }
    }
}
