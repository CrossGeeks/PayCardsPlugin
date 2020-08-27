using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Runtime;
using Cards.Pay.Paycardsrecognizer.Sdk;

namespace Plugin.PayCards
{
    public class PayCardsRecognizerService : IPayCardsRecognizerService
    {
        static TaskCompletionSource<PayCard> _cardTcs;
        static int _requestCodeScanCard = 1734;
        static Activity _activity;

        public static void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if(requestCode == _requestCodeScanCard)
            {
                if(resultCode == Result.Ok && data != null)
                {
                    Card card = data.GetParcelableExtra(ScanCardIntent.ResultPaycardsCard).JavaCast<Card>();

                    _cardTcs.TrySetResult(new PayCard(card.CardHolderName, card.CardNumber, card.ExpirationDate));
                }
                else
                {
                    _cardTcs.TrySetCanceled();
                }
            }
        }

        public static void Initialize(Activity activity, int requestCode = 1734)
        {
            _requestCodeScanCard = requestCode;
            _activity = activity;
        }

        public Task<PayCard> ScanAsync()
        {
            _cardTcs = new TaskCompletionSource<PayCard>();

            if (_activity == null)
            {
                _cardTcs.SetException(new Exception("Plugin not initialized should call PayCardsRecognizerService.Initialize(Activity activity,int requestCode) before calling this method"));
            }
            using (var builder = new ScanCardIntent.Builder(_activity))
            {
                _activity.StartActivityForResult(builder.Build(), _requestCodeScanCard);
            }
            return _cardTcs.Task;
        }
    }
}
