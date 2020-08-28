using System;
using System.Windows.Input;
using Xamarin.Forms;
using Plugin.PayCards;

namespace PayCardRecognizerSample.ViewModels
{
    public class MainViewModel
    {

        public ICommand ScanCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        var card = await CrossPayCards.Current.ScanAsync();
                        await App.Current.MainPage.DisplayAlert("Result", $"{card.HolderName}\n{card.CardNumber}\n{card.ExpirationDate}","Ok");
                    }
                    catch(Exception ex)
                    {
                        await App.Current.MainPage.DisplayAlert("Error", ex.ToString(), "Ok");
                    }

                });
            }
        }
    }
}
