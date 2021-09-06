using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SunExpert.SisAvikar.Domain;
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
    public class AreaController : ControllerBase
    {
        IAvikarService _generalService;
        private ObjectResult status;
        public AreaController() => _generalService = (IAvikarService)(new AvikarService());

        [HttpGet]
        [Route("List")]
        public IActionResult List()
        {
            try{
                status = Ok(_generalService.AreaList());
            }catch (Exception e){
                status = BadRequest(e.Message);
            }

            return status;
        }

        [HttpPost]
        [Route("save")]
        public IActionResult Save([FromBody] Area obj) //int usr
            {
            try{
                int response = _generalService.AreaSave(obj);
                status = Ok(response);
            }catch (Exception e){
                status = BadRequest(e.Message);
            }
            return status;
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] Area obj) //int usr
        {
            try
            {
                int response = _generalService.AreaSave(obj);
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
