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
    public class MesaController : ControllerBase
    {
        IAvikarService _generalService;
        private ObjectResult status;
        public MesaController() => _generalService = (IAvikarService)(new AvikarService());

        [HttpGet]
        [Route("List")]
        public IActionResult List()
        {
            try
            {
                status = Ok(_generalService.MesaList());
            }
            catch (Exception e)
            {
                status = BadRequest(e.Message);
            }

            return status;
        }

        [HttpPost]
        [Route("save")]
        public IActionResult Save([FromBody] Mesa obj) //int usr
        {
            try
            {
                int response = _generalService.MesaSave(obj);
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
