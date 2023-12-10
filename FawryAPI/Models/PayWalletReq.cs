namespace FawryAPI.Models
{
    public class PayWalletReq:BasePayReq
    {
        public string DebitMobileWalletNo { get; set; }

        public PayWalletReq(string debitMobileWalletNo)
        {
            DebitMobileWalletNo = debitMobileWalletNo;
            Signature = HashingSignature(MerchantCode + MerchantRefNum + PaymentMethod + Amount + DebitMobileWalletNo);
        }
    }
}
