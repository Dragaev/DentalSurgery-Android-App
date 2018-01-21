using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Messaging;

namespace DentalApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class Item
    {
        public string Title { get; set; }
        public string Price { get; set; }
    }
   
    public partial class PriceListPage : ContentPage
    {
      
        public List<Item> Items { get; set; }
        public PriceListPage()
        {
            InitializeComponent();
            Items = new List<Item>
{
new Item {Title="Консультация врача-терапевта" , Price="100 рублей" },
new Item {Title="Оформление истории болезни" , Price="100 рублей" },
new Item {Title="Визиографическое исследование", Price="220 рублей" },
new Item {Title="Наложение временной пломбы", Price="120 рублей"},
new Item {Title="Ретракция десны", Price="70 рублей" },
new Item {Title="Трепанация штампованой коронки", Price="100 рублей" }
};
            this.BindingContext = this;
       
        }
        public async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            Item selectedItem = e.Item as Item;
            if (selectedItem != null)
                await DisplayAlert("", $"{selectedItem.Title} - {selectedItem.Price}", "OK");
        }
    }
}