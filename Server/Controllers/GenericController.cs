using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Repositories.Contracts;

namespace Server.Controllers
{
    // A generic controller that can be used for any entity
    // It provides a common endpoint structure for CRUD operations.
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<T>(IGenericRepositoryInterface<T> genericRepositoryInterface) : Controller where T : class
    {
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await genericRepositoryInterface.GetAll());
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Sorry, Invalid request sent, Try again");
            }
            return Ok(await genericRepositoryInterface.DeleteById(id));
        }

        [HttpGet("singleget/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Sorry, Invalid request sent, Try again");
            }
            return Ok(await genericRepositoryInterface.GetById(id));
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(T model)
        {
            if (model is null)
            {
                return BadRequest("Sorry, Invalid request made, Try again");
            }
            return Ok(await genericRepositoryInterface.Insert(model));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(T model)
        {
            if (model is null)
            {
                return BadRequest("Sorry, Invalid request made, Try again");
            }
            return Ok(await genericRepositoryInterface.Update(model));
        }
    }
}