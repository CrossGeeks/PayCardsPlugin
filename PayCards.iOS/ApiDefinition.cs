using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace PayCards
{
	// @interface PayCardsRecognizerResult : NSObject
	[BaseType(typeof(NSObject))]
	interface PayCardsRecognizerResult
	{
		// @property (copy) NSString * _Nullable recognizedNumber;
		[NullAllowed, Export("recognizedNumber")]
		string RecognizedNumber { get; set; }

		// @property (copy) NSString * _Nullable recognizedExpireDateMonth;
		[NullAllowed, Export("recognizedExpireDateMonth")]
		string RecognizedExpireDateMonth { get; set; }

		// @property (copy) NSString * _Nullable recognizedExpireDateYear;
		[NullAllowed, Export("recognizedExpireDateYear")]
		string RecognizedExpireDateYear { get; set; }

		// @property (copy) NSString * _Nullable recognizedHolderName;
		[NullAllowed, Export("recognizedHolderName")]
		string RecognizedHolderName { get; set; }

		// @property (assign, nonatomic) CGRect recognizedNumberRect;
		[Export("recognizedNumberRect", ArgumentSemantic.Assign)]
		CGRect RecognizedNumberRect { get; set; }

		// @property (copy) UIImage * _Nullable image;
		[NullAllowed, Export("image", ArgumentSemantic.Copy)]
		UIImage Image { get; set; }

		// @property (copy) NSDictionary<NSString *,id> * _Nonnull dictionary;
		[Export("dictionary", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> Dictionary { get; set; }

		// @property (assign, nonatomic) BOOL isCompleted;
		[Export("isCompleted")]
		bool IsCompleted { get; set; }
	}

	[Static]
	partial interface Constants
	{
		// extern NSString *const _Nonnull WOCardNumber;
		[Field("WOCardNumber", "__Internal")]
		NSString WOCardNumber { get; }

		// extern NSString *const _Nonnull WOExpDate;
		[Field("WOExpDate", "__Internal")]
		NSString WOExpDate { get; }

		// extern NSString *const _Nonnull WOHolderName;
		[Field("WOHolderName", "__Internal")]
		NSString WOHolderName { get; }

		// extern NSString *const _Nonnull WOHolderNameRaw;
		[Field("WOHolderNameRaw", "__Internal")]
		NSString WOHolderNameRaw { get; }

		// extern NSString *const _Nonnull WONumberConfidences;
		[Field("WONumberConfidences", "__Internal")]
		NSString WONumberConfidences { get; }

		// extern NSString *const _Nonnull WOHolderNameConfidences;
		[Field("WOHolderNameConfidences", "__Internal")]
		NSString WOHolderNameConfidences { get; }

		// extern NSString *const _Nonnull WOExpDateConfidences;
		[Field("WOExpDateConfidences", "__Internal")]
		NSString WOExpDateConfidences { get; }

		// extern NSString *const _Nonnull WOCardImage;
		[Field("WOCardImage", "__Internal")]
		NSString WOCardImage { get; }

		// extern NSString *const _Nonnull WOPanRect;
		[Field("WOPanRect", "__Internal")]
		NSString WOPanRect { get; }

		// extern NSString *const _Nonnull WODateRect;
		[Field("WODateRect", "__Internal")]
		NSString WODateRect { get; }

		// extern NSString *const _Nonnull WONumberSamples;
		//[Field("WONumberSamples", "__Internal")]
		//NSString WONumberSamples { get; }

		// extern NSString *const _Nonnull WODateSamples;
		//[Field("WODateSamples", "__Internal")]
		//NSString WODateSamples { get; }

		// extern NSString *const _Nonnull WOHolderSamples;
		//[Field("WOHolderSamples", "__Internal")]
		//NSString WOHolderSamples { get; }
	}

	// @interface PayCardsRecognizer : NSObject
	[BaseType(typeof(NSObject))]
	interface PayCardsRecognizer
	{
		// -(instancetype _Nonnull)initWithDelegate:(id<PayCardsRecognizerPlatformDelegate> _Nonnull)delegate resultMode:(PayCardsRecognizerResultMode)resultMode container:(UIView * _Nonnull)container frameColor:(UIColor * _Nonnull)frameColor;
		[Export("initWithDelegate:resultMode:container:frameColor:")]
		IntPtr Constructor(IPayCardsRecognizerPlatformDelegate @delegate, PayCardsRecognizerResultMode resultMode, UIView container, UIColor frameColor);

		// -(instancetype _Nonnull)initWithDelegate:(id<PayCardsRecognizerPlatformDelegate> _Nonnull)delegate recognizerMode:(PayCardsRecognizerDataMode)recognizerMode resultMode:(PayCardsRecognizerResultMode)resultMode container:(UIView * _Nonnull)container frameColor:(UIColor * _Nonnull)frameColor;
		[Export("initWithDelegate:recognizerMode:resultMode:container:frameColor:")]
		IntPtr Constructor(IPayCardsRecognizerPlatformDelegate @delegate, PayCardsRecognizerDataMode recognizerMode, PayCardsRecognizerResultMode resultMode, UIView container, UIColor frameColor);

		[Wrap("WeakDelegate")]
		[NullAllowed]
		IPayCardsRecognizerPlatformDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<PayCardsRecognizerPlatformDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// -(void)startCamera;
		[Export("startCamera")]
		void StartCamera();

		// -(void)startCameraWithOrientation:(UIInterfaceOrientation)orientation;
		[Export("startCameraWithOrientation:")]
		void StartCameraWithOrientation(UIInterfaceOrientation orientation);

		// -(void)stopCamera;
		[Export("stopCamera")]
		void StopCamera();

		// -(void)pauseRecognizer;
		[Export("pauseRecognizer")]
		void PauseRecognizer();

		// -(void)resumeRecognizer;
		[Export("resumeRecognizer")]
		void ResumeRecognizer();

		// -(void)setOrientation:(UIInterfaceOrientation)orientation;
		[Export("setOrientation:")]
		void SetOrientation(UIInterfaceOrientation orientation);

		// -(void)turnTorchOn:(BOOL)on withValue:(float)value;
		[Export("turnTorchOn:withValue:")]
		void TurnTorchOn(bool on, float value);
	}

	// @protocol PayCardsRecognizerPlatformDelegate
	[Protocol, Model(AutoGeneratedName = true)]
	interface PayCardsRecognizerPlatformDelegate
	{
		// @required -(void)payCardsRecognizer:(PayCardsRecognizer * _Nonnull)payCardsRecognizer didRecognize:(PayCardsRecognizerResult * _Nonnull)result;
		[Abstract]
		[Export("payCardsRecognizer:didRecognize:")]
		void DidRecognize(PayCardsRecognizer payCardsRecognizer, PayCardsRecognizerResult result);
	}

	interface IPayCardsRecognizerPlatformDelegate
	{
	}
}