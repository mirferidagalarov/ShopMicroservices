using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Cargo.Business.Abstract;
using Shop.DTOs.CargoCompanyDTOs;
using Shop.Entities.Concrete;

namespace Shop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CargoCompanyController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;
        public CargoCompanyController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = _cargoCompanyService.TGetAll();
            return Ok(data);
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var data = _cargoCompanyService.TGetById(id);
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Add(CargoCompanyAddDTO  cargoCompanyAddDTO)
        {
            CargoCompany company = new CargoCompany()
            {
                Name = cargoCompanyAddDTO.Name,
            };
            _cargoCompanyService.TAdd(company);
            return Ok("data added  successfuly");
        }

        [HttpPut]
        public IActionResult Update(CargoCompanyUpdateDTO  cargoCompanyUpdateDTO)
        {
            CargoCompany cargoCompany = new CargoCompany()
            {
                Id = cargoCompanyUpdateDTO.Id,
                Name = cargoCompanyUpdateDTO.Name,
            };
            _cargoCompanyService.TUpdate(cargoCompany);
            return Ok("data update successfuly");
        }

        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            _cargoCompanyService.TDelete(id);
            return Ok("data deleted successfuly");
        }





    }
}
