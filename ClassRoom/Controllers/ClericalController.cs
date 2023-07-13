using ApplicationService.DataProviders;
using ApplicationService.DTOS;
using Microsoft.AspNetCore.Mvc;

namespace ClassRoom.Controllers
{
    [Route("Clerk")]
    [ApiController]
    public class ClericalController : Controller
    {
        public ClericalController(IClerkDataProvider clerkDataProvider)
        {
            _clerkDataProvider = clerkDataProvider;
        }

        private readonly IClerkDataProvider _clerkDataProvider;

        [HttpPost("Add")]
        public void Add(ClerkDTO clerk)
        {
            _clerkDataProvider.Add(clerk);
        }


        [HttpGet("Get")]
        public ClerkDTO Get(long id)
        {
            return _clerkDataProvider.Get(id);
        }


    }
}
