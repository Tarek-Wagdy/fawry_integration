
namespace FawryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly IGeneric<Client> _GenericRepo;

        public ClientController(IGeneric<Client> genericRepo)
        {
            _GenericRepo = genericRepo;
        }
        [HttpGet]
        public List<Client> GetAll()
        {
            return _GenericRepo.GetAll();
        }
    }
}
