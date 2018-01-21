using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Messaging;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DentalApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModalPage : ContentPage
    { string adress = "outlinemaker@gmail.com";
       
        public ModalPage()
        {
              InitializeComponent();
        }
       

        private void SendBtn_Clicked(object sender, EventArgs e)
        {
            string message = surnameEntryCell.Text+"\n"+nameEntryCell.Text+ "\n" + patronymicEntryCell.Text+ "\n" + phoneEntryCell.Text+ "\n" + emailEntryCell.Text;
            var emailMessenger = CrossMessaging.Current.EmailMessenger;
            if (emailMessenger.CanSendEmail)
            {
                emailMessenger.SendEmail(adress, "Заявка", message);
            }
        }
    }
}