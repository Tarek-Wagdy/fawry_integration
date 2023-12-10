namespace FawryAPI.Models
{
    public abstract class BasePayReq
    {
        public string MerchantCode { get; set; }
        public int MerchantRefNum { get; set; }
        public int? CustomerProfileId { get; set; }
        public string PaymentMethod { get; set; }

        public string? CustomerName { get; set; }
        public string CustomerMobile { get; set; }
        public string CustomerEmail { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string? OrderWebHookUrl { get; set; }
        public string Language { get; set; }
        public ChargeItem[] ChargeItems { get; set; }
        public string Signature { get; set; }

        protected decimal calculateCost()
        {
            decimal cost = 0;
            foreach(var item in ChargeItems)
            {
                cost += (item.Quantity * item.Price);
            }
            return cost;
        }

        public BasePayReq()
        {
            MerchantCode = "1tSa6uxz2nTwlaAmt38enA==";
            MerchantRefNum = 231246546;
            CustomerName = "Tarek Wagdy";
            CustomerMobile = "01234567891";
            CustomerEmail = "example@gmail.com";
            Language = "en-gb";
            ChargeItems = new ChargeItem[] {new ChargeItem(){
                                        Id=897,Describtion="Item Description",Price=250.50m,
                                   Quantity = 1.00m
                                 } };
            Amount = calculateCost();
            PaymentMethod = "PayUsingCC";
            Description = "example description";
        }

        public string HashingSignature(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }
    }
}
