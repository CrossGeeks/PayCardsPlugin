using System;
using System.Windows.Input;
using Xamarin.Forms;
using Plugin.PayCards;
using System.ComponentModel;
using System.Diagnostics;

namespace PayCardRecognizerSample.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ICommand ScanCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        Card = await CrossPayCards.Current.ScanAsync().ConfigureAwait(true);
                    }
                    catch (Exception ex){
                        Debug.WriteLine(ex);
                    }
                });
            }
        }

        public PayCard Card
        {
            set
            {
                if (_card != value)
                {
                    _card = value;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Card)));
                }
            }
            get => _card;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private PayCard _card;
    }
}
