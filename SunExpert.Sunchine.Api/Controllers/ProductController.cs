using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SunExpert.SisAvikar.Domain.Entity;
using SunExpert.SisAvikar.Service;
using SunExpert.SisAvikar.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunExpert.Sunchine.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IAvikarService _generalService;
        private ObjectResult status;
        public ProductController() => _generalService = (IAvikarService)(new AvikarService());
        
        
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                status = Ok(_generalService.ProductList());
            }
            catch (Exception e)
            {
                status = BadRequest(e.Message);
            }

            return status;
        }


        [HttpPost]
        public IActionResult Save([FromBody] Product obj)
        {
            try
            {
                int response = _generalService.ProductSave(obj);
                status = Ok(response);
            }
            catch (Exception e)
            {
                status = BadRequest(e.Message);
            }
            return status;
        }
    }
}
