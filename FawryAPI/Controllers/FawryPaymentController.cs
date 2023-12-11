

namespace FawryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FawryPaymentController : ControllerBase
    {

        private readonly ApplicationContext _applicationContext;
        public FawryPaymentController(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }


        [HttpPost("PayWithCard")]
        public dynamic CheckoutWithCard(int invoiceId, [FromServices]IFawryCardPayment paymentService)
        {
            try
            {
                var ReturnObj= paymentService.Pay(new PayCardReq(10, 2025, 7, 232));
                markInvoiceAsPaid(invoiceId,"Card");
                return ReturnObj;
                
            }
            catch(Exception ex) 
            {
                return ex;
            }
            

        }
        [HttpPost("PayWithWallet")]
        public object CheckoutWithMWallet(int invoiceId, [FromServices] IFawryWalletPayment paymentService)
        {

           
            try
            {
                var ReturnObj =paymentService.Pay(new PayWalletReq("07775000"));
                markInvoiceAsPaid(invoiceId,"Wallet");
                return ReturnObj;

            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        private void markInvoiceAsPaid(int invoiceId,string PaymentType)
        {
            Invoice invoice = _applicationContext.invoices.FirstOrDefault(i => i.Id == invoiceId);
            invoice.IsPaid = true;
            invoice.PaymentType = PaymentType;
            _applicationContext.SaveChanges();
        }
    }
}
