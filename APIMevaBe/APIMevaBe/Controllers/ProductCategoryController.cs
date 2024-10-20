using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRN221_MeVaBe_Repo.Models;
using Services.Interfaces;
using Services.Repositories;

namespace APIMevaBe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private IUnitOfWork _repository = new UnitOfWork();

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repository.ProductCategoryRepository.Get();
            if (result.Any()) return Ok(result);
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetEquipmentById(string id)
        {
            var products = _repository.ProductCategoryRepository.GetByID(id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (products != null)
            {
                return Ok(products);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductCategory Product)
        {
            _repository.ProductCategoryRepository.Insert(Product);
            _repository.Save();
            return Ok("Create ProductCategory success");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_repository.ProductCategoryRepository.GetByID(id) != null)
            {
                _repository.ProductCategoryRepository.Delete(id);
                _repository.Save();
                return Ok("delete thanh cong");
            }
            return NotFound();
        }
    }
}
