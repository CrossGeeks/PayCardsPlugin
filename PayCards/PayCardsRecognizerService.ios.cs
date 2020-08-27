using System.Threading.Tasks;
using Foundation;
using PayCards;
using UIKit;

namespace Plugin.PayCards
{
    public class PayCardsRecognizerService : NSObject, IPayCardsRecognizerService, IPayCardsRecognizerPlatformDelegate
    {
        TaskCompletionSource<PayCard> _cardTcs;
        RecognizerViewController _recognizerViewController;

        [Export("payCardsRecognizer:didRecognize:")]
        public void DidRecognize(PayCardsRecognizer payCardsRecognizer, PayCardsRecognizerResult result)
        {
            if (result?.IsCompleted ?? false)
            {
                _cardTcs.TrySetResult(new PayCard(result.RecognizedHolderName, result.RecognizedNumber, $"{result.RecognizedExpireDateMonth}/{result.RecognizedExpireDateYear}"));

                _recognizerViewController.DismissViewController(true, null);
            }
        }

        public Task<PayCard> ScanAsync()
        {
            _cardTcs = new TaskCompletionSource<PayCard>();
            var window = UIApplication.SharedApplication.KeyWindow;
            var _viewController = window.RootViewController;
            while (_viewController.PresentedViewController != null)
                _viewController = _viewController.PresentedViewController;

             _recognizerViewController = new RecognizerViewController(this);
            
             _viewController?.PresentViewController(_recognizerViewController, true, null);

            return _cardTcs.Task;

        }

    }
}
