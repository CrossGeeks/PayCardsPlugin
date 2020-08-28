using System;
using System.Linq;
using CoreGraphics;
using PayCards;
using UIKit;

namespace Plugin.PayCards
{
    public partial class RecognizerViewController : UIViewController
    {
        IPayCardsRecognizerPlatformDelegate _recognizerDelegate;
        PayCardsRecognizer _recognizer;
        UIButton _closeButton;

        public RecognizerViewController(IPayCardsRecognizerPlatformDelegate recognizerDelegate) : base()
        {
            _recognizerDelegate = recognizerDelegate;
        }


        public RecognizerViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            _recognizer = new PayCardsRecognizer(_recognizerDelegate,PayCardsRecognizerResultMode.Async, container: View, UIColor.Green);

            _closeButton = new UIButton(UIButtonType.Close);

            _closeButton.TouchUpInside += Close;


        }

        private void Close(object sender, EventArgs e)
        {
           DismissViewController(true, null);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
           
            _recognizer.StartCamera();
            var sb = View.Subviews.FirstOrDefault();

            if(_closeButton.Superview == null)
            {
                _closeButton.SetTitle("Close", UIControlState.Normal);
               
                sb.AddSubview(_closeButton);
                _closeButton.Frame = new CGRect(sb.Bounds.Width - 100, 0, 100, 80);
            }
           
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);

            _recognizer.StopCamera();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _closeButton.TouchUpInside -= Close;
        }
    }
}

