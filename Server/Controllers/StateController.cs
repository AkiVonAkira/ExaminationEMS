using BaseLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Repositories.Contracts;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController(IGenericRepositoryInterface<State> genericRepositoryInterface) : GenericController<State>(genericRepositoryInterface)
    {
    }
}