namespace Plugin.PayCards
{
    public class PayCard
    {
        public PayCard(string holderName, string cardNumber, string expirationDate)
        {
            HolderName = holderName;
            CardNumber = cardNumber;
            ExpirationDate = expirationDate;
        }

        public string HolderName { get; }

        public string CardNumber { get; }

        public string ExpirationDate { get; }
    }
}
