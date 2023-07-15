using System.Threading.Tasks;
using ApplicationService.DataProviders;
using ApplicationService.DTOS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassRoom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClericalController : Controller
    {
        public ClericalController(IClerkDataProvider clerkDataProvider)
        {
            _clerkDataProvider = clerkDataProvider;
        }

        private readonly IClerkDataProvider _clerkDataProvider;

        [HttpPost("Add")]
        public long Add(ClerkDTO clerk)
        {
            return _clerkDataProvider.Add(clerk);
        }

        [HttpGet("Get")]
        public ClerkDTO Get(long id)
        {
          return _clerkDataProvider.Get(id);
        }
    }
}
