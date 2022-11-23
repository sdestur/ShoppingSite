using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using Entities.DTOs.ProductDtos;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdcutContollers : ControllerBase
    {
        IProductService _productService;
        


        public ProdcutContollers(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("Ürün ekle")]
        public IActionResult Add([FromQuery] ProductAddDto product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                //if())


                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpPost("Güncelleme")]
        public IActionResult Update([FromQuery] Product product)
        {
            var result = _productService.Update(product);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete([FromQuery] Product product)
        {
            var result = _productService.Delete(product);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }
    }
}
