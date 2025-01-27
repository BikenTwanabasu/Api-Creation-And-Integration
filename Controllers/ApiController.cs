using ApiToConsume.Model;
using ApiToConsume.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiToConsume.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        public readonly IDemoServices _demoServices;

        public ApiController(IDemoServices demoServices)
        {
            _demoServices = demoServices;
        }
        [HttpPost]
        public IActionResult Create(DemoModel model)
        {
            var a = _demoServices.createData(model);
            if (!a)
            {
                return BadRequest("Invalid User Request");
            }
            return Ok("Data inserted successfully");
        }
        [HttpGet("View")]
        public IActionResult View()
        {
            var a = _demoServices.get();
            if (a == null)
            {
                return NotFound("Resquested Data not found");
            }
            else
            {
                return Ok(a);
            }
        }
        [HttpGet("ViewById/{Id}")]
        public IActionResult ViewById(DemoModel model)
        {
            var a = _demoServices.getById(model);
            if (model.Id == null)
            {
                return BadRequest("Id cannot be 0");
            }
            
            else if(a==null)
            {
                return NotFound("Resquested Data doesnot exists or couldnot be found");
            }
            else
            {
                return Ok(a);
            }
        }
        [HttpPut]
        public IActionResult Edit(DemoModel model)
        {
            var a =_demoServices.edit(model);
            if (!a)
            {
                return BadRequest("Invalid request by the user");

            }
            else
            {
                return Ok("Data updated Successfully");
            }
        }
        [HttpDelete]
        public IActionResult Delete(DemoModel model)
        {
            var a = _demoServices.delete(model);
            if (!a)
            {
                return BadRequest("Invalid request by the user");
            }
            else
            {
                return Ok("Data Deleted Successfully");
            }

        }


    }
}
