using System;
using Xamarin.Forms;
using Plugin.Messaging;

namespace DentalApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void ToModalPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ModalPage());
        }
        private async void ToInformationPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CommonPage());
        }

        private void CallButton_Clicked(object sender, EventArgs e)
        {
            var phoneDialer = CrossMessaging.Current.PhoneDialer;
            if (phoneDialer.CanMakePhoneCall)
                phoneDialer.MakePhoneCall("+79139476272");
        }
    }
}
