namespace TestClient.Models
{
    public class TestClientModel
    {
        public string FromEmail { get; set; }

        public string ToEmail { get; set; }

        public long CreditCardNumber { get; set; }

        public string CardHolderName { get; set; }

        public decimal Amount { get; set; }

    }
}