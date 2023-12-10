 using Newtonsoft.Json;
namespace FawryAPI.Repositories
{
    public class FawryCardPaymentRepository:IFawryCardPayment
    {

        private readonly ApplicationContext _applicationContext;
        public FawryCardPaymentRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }


        public dynamic Pay(BasePayReq req)
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
                String returnUrl = PostCardJson("https://atfawry.fawrystaging.com/ECommerceWeb/Fawry/payments/charge", req);
                ServicePointManager.ServerCertificateValidationCallback = null;
                return returnUrl;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        //public string FawryPayCard(int invoiceId)
        //{
        //    try
        //    {
        //         invoice = _applicationContext.invoices.SingleOrDefault(i => i.Id == invoiceId);
        //        payCardReq.MerchantCode = "1tSa6uxz2nTwlaAmt38enA==";
        //        payCardReq.MerchantRefNum = 231246546;
        //        payCardReq.CustomerName = "Tarek Wagdy";
        //        payCardReq.CustomerMobile = "01234567891";
        //        payCardReq.CustomerEmail = "example@gmail.com";
        //        payCardReq.CardNumber = 4242424242424242;
        //        payCardReq.CardExpiryYear = 21;
        //        payCardReq.CardExpiryMonth = 5;
        //        payCardReq.Cvv = 123;
        //        payCardReq.Enable3DS = true;
        //        payCardReq.AuthCaptureModePaymen = false;
        //        payCardReq.ReturnUrl = "https://www.google.com/";
        //        payCardReq.Language = "en-gb";
        //        payCardReq.ChargeItems = new ChargeItem[] {new ChargeItem(){
        //                                Id=897,Describtion="Item Description",Price=250.50m,
        //                           Quantity = 1.00m
        //                         } };
        //        payCardReq.Amount = invoice.Cost;
        //        payCardReq.PaymentMethod = "PayUsingCC";
        //        payCardReq.Description = "example description";
        //        payCardReq.Signature = HashingSignature(payCardReq.MerchantCode + payCardReq.MerchantRefNum + payCardReq.PaymentMethod + payCardReq.Amount);

        //        ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
        //        ReturnUrl = PostCardJson("https://atfawry.fawrystaging.com/ECommerceWeb/Fawry/payments/charge", payCardReq);
        //        ServicePointManager.ServerCertificateValidationCallback = null;

        //    }
        //    catch(Exception ex) 
        //    {
        //        ReturnUrl = ex.Message;
        //    }
        //    if (ReturnUrl != "")
        //    {
        //        invoice.IsPaid = true;
        //        invoice.PaymentType = "Card";
        //        _applicationContext.SaveChanges();
        //    }
        //    return ReturnUrl;

        //}

        //public object FawryPayMWallet(int invoiceId)
        //{
        //    //try
        //    //{
        //        var invoice = _applicationContext.invoices.SingleOrDefault(i => i.Id == invoiceId);
        //        payWalletReq.MerchantCode = "1tSa6uxz2nTwlaAmt38enA==";
        //        payWalletReq.MerchantRefNum = 231246546;
        //        payWalletReq.CustomerName = "Tarek Wagdy";
        //        payWalletReq.CustomerMobile = "01008282688";
        //        payWalletReq.CustomerEmail = "example@gmail.com";
        //        payWalletReq.DebitMobileWalletNo = "01009914491";
        //        payWalletReq.Language = "en-gb";
        //        payWalletReq.ChargeItems = new ChargeItem[] {new ChargeItem(){
        //                                Id=897,Describtion="Item Description",Price=250.50m,
        //                           Quantity = 1.00m
        //                         } };
        //        payWalletReq.Amount = invoice.Cost;
        //        payWalletReq.PaymentMethod = "MWALLET";
        //        payWalletReq.Description = "example description";
        //        payWalletReq.Signature =HashingSignature(payWalletReq.MerchantCode + payWalletReq.MerchantRefNum + payWalletReq.PaymentMethod + payWalletReq.Amount + payWalletReq.DebitMobileWalletNo);
        //        ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
        //        ReturnObj = PostWalletJson("https://atfawry.fawrystaging.com/ECommerceWeb/Fawry/payments/charge", payWalletReq);
        //        ServicePointManager.ServerCertificateValidationCallback = null;

        //        if (ReturnObj != null)
        //        {
        //            invoice.IsPaid = true;
        //            invoice.PaymentType = "Wallet";
        //            _applicationContext.SaveChanges();
        //        }



        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    ReturnObj = ex;
        //    //}
        //    return ReturnObj;
        //}



        private static string PostCardJson(string uri, BasePayReq payCardReq)
        {
            string postData = JsonConvert.SerializeObject(payCardReq);
            byte[] bytes = Encoding.UTF8.GetBytes(postData);
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentLength = bytes.Length;
            httpWebRequest.ContentType = "application/json";
            using (Stream requestStream = httpWebRequest.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Count());
            }
            var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            if (httpWebResponse.StatusCode != HttpStatusCode.OK)
            {
                string message = String.Format("GET failed. Received HTTP {0}", httpWebResponse.StatusCode);
                throw new ApplicationException(message);
            }
            dynamic response = JsonConvert.DeserializeObject(httpWebResponse.GetResponseStream().ReadToEnd());
            try
            {
                return response.nextAction.redirectUrl;
            }
            catch (Exception ex)
            {
                return "https://atfawry.fawrystaging.com/atfawry/plugin/3ds/7104048097";
            }

        }

    }
}
