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
                var ReturnObj= PostCardJson("https://atfawry.fawrystaging.com/ECommerceWeb/Fawry/payments/charge", req);
                ServicePointManager.ServerCertificateValidationCallback = null;
                return ReturnObj;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        private object PostCardJson(string uri, BasePayReq payCardReq)
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
