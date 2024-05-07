using BaseLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Repositories.Contracts;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController(IGenericRepositoryInterface<Section>genericRepositoryInterface) : GenericController<Section>(genericRepositoryInterface)
    {
    }
}
