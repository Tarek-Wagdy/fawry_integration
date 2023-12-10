namespace FawryAPI.Models
{
    public class PayCardReq:BasePayReq
    {
   
        public long CardNumber { get; set; }
        public int CardExpiryYear { get; set; }
        public int CardExpiryMonth { get; set; }
        public int Cvv { get; set; }
        public bool Enable3DS { get; set; }
        public bool AuthCaptureModePaymen { get; set; }
        public string ReturnUrl { get; set; }

        public PayCardReq(long cardNumber, int expiryYear, int expiryMonth, int cvv):base()
        {
            CardNumber = cardNumber;
            CardExpiryYear = expiryYear;
            CardExpiryMonth = expiryMonth;
            Cvv = cvv;
            Enable3DS = true;
            AuthCaptureModePaymen = true;
            Enable3DS = true;
            AuthCaptureModePaymen = false;
            ReturnUrl = "https://www.google.com/";

            Signature = HashingSignature(MerchantCode + MerchantRefNum + PaymentMethod + Amount +  CardNumber + CardExpiryYear + CardExpiryMonth + Cvv + ReturnUrl);

        }

    }
}
