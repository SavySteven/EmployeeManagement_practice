using BasicLibrary.Entities;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Repositories.Contracts;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralDeparmentController(IGenericRepositoryInterface<GeneralDepartment> genericRepositoryInterface)
        : GenericController<GeneralDepartment>(genericRepositoryInterface)
    {

    }
}
