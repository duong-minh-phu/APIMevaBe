using Microsoft.AspNetCore.Mvc;
using PRN221_MeVaBe_Repo.Models;
using Services.Interfaces;
using Services.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIMevaBe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IUnitOfWork _repository = new UnitOfWork();
        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _repository.ProductRepository.Get();
            if (result.Any()) return Ok(result);
            return NoContent();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public IActionResult GetEquipmentById(string id)
        {
            var products = _repository.ProductRepository.GetByID(id);
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

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] Product Product)
        {
            _repository.ProductRepository.Insert(Product);
            _repository.Save();
            return Ok("Create product success");
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            if (_repository.ProductRepository.GetByID(id) != null)
            {
                var _product = _repository.ProductRepository.GetByID(id);
                if (product.ProductName != null)
                {
                    _product.ProductName = product.ProductName;
                }
                if (product.Price != null)
                {
                    _product.Price = product.Price;
                }
                if (product.Description != null)
                {
                    _product.Description = product.Description;
                }

                _repository.ProductRepository.Update(_product);
                _repository.Save();
                return Ok("Update product success");
            }
            return NotFound();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_repository.ProductRepository.GetByID(id) != null)
            {
                _repository.ProductRepository.Delete(id);
                _repository.Save();
                return Ok("delete thanh cong");
            }
            return NotFound();
        }
    }
}
