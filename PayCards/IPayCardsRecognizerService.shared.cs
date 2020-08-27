using System.Threading.Tasks;

namespace Plugin.PayCards
{
    public interface IPayCardsRecognizerService
    {
        Task<PayCard> ScanAsync();
    }
}
