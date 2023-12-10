

namespace FawryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IGeneric<Invoice> _GenericRepo;

        public InvoiceController(IGeneric<Invoice> genericRepo)
        {
            _GenericRepo = genericRepo;
        }
        [HttpGet]
        public List<Invoice> GetAll()
        {
            return _GenericRepo.GetAll();
        }
    }
}
