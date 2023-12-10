using Newtonsoft.Json;

namespace FawryAPI.Repositories
{
    public class FawryWalletPaymentRepository:IFawryWalletPayment
    {


        private static object PostWalletJson(string uri, BasePayReq payWalletReq)
        {
            dynamic response;
            string postData = JsonConvert.SerializeObject(payWalletReq);
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
            response = JsonConvert.DeserializeObject(httpWebResponse.GetResponseStream().ReadToEnd());

            return response;


        }

        public dynamic Pay(BasePayReq req)
        {
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            var ReturnObj = PostWalletJson("https://atfawry.fawrystaging.com/ECommerceWeb/Fawry/payments/charge", req);
            ServicePointManager.ServerCertificateValidationCallback = null;
            return ReturnObj;

        }
    }
}
