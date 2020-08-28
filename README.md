# PayCards Plugin for Xamarin iOS and Android

[![Build Status](https://dev.azure.com/CrossGeeks/Plugins/_apis/build/status/PayCards%20Plugin%20CD%20Pipeline?branchName=master)](https://dev.azure.com/CrossGeeks/Plugins/_build/latest?definitionId=15&branchName=master)

Simple cross platform plugin that uses [Pay.Cards](https://pay.cards) library to scan credit card information.

### Setup
* Available on NuGet: http://www.nuget.org/packages/Plugin.PayCards [![NuGet](https://img.shields.io/nuget/v/Plugin.PayCards.svg?label=NuGet)](https://www.nuget.org/packages/Plugin.PayCards/)
* Install into your .NETStandard project and Client projects.

**Platform Support**

|Platform|Version|
| ------------------- | :------------------: |
|Xamarin.iOS|iOS 12+|
|Xamarin.Android|API 9+|

### API Usage

Call **CrossPayCards.Current** from any project to gain access to APIs.

### Getting Started

After installing the package in your shared, iOS and Android projects you should do the following setup on each platform:

#### Android Setup

Call **PayCardsRecognizerService.Initialize** in MainActivity OnCreate method

```cs
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            PayCardsRecognizerService.Initialize(this);
            LoadApplication(new App());
        }
```

Override MainActivity OnActivityResult and call **PayCardsRecognizerService.OnActivityResult**

```
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            PayCardsRecognizerService.OnActivityResult(requestCode, resultCode, data);
        }
```

#### iOS Setup

Add Camera Permission in Info.plist

```xml
	<key>NSCameraUsageDescription</key>
	<string>This application needs camera access</string>
```

**Now you are ready to to scan credit cards!**

### Usage

```cs
  var cardInfo = await CrossPayCards.Current.ScanAsync();
  System.Debug.WriteLine("Result", $"{card.HolderName}\n{card.CardNumber}\n{card.ExpirationDate}","Ok");
```
