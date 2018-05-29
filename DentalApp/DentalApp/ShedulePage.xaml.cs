using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DentalApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShedulePage : ContentPage
    {
        public List<Doctor> Doctors { get; set; }
        public ShedulePage()
        {
            Title = "Расписание докторов";
            Doctors = new List<Doctor>           
            {                
                new Doctor {Name="Лебзак Марина Геннадьевна", TimeOfWork="с 8-30 до 14-00 по четным ",TimeOfWorkSecond="с 14-30  до 20-00 по нечетным", ImagePath="lebzak.jpg", Speciality="Стоматолог-терапевт"},
                new Doctor {Name="Гобрусева Лариса Анатольевна", TimeOfWork="с 8-30 до 14-00 по нечетным",TimeOfWorkSecond="с 14-30  до 20-00 по четным", ImagePath="gobruseva.jpg", Speciality ="Стоматолог-терапевт"},
                new Doctor {Name="Никулин Андрей Петрович", TimeOfWork="с 8-30 до 20-00",TimeOfWorkSecond="", ImagePath="nikulin.jpg",Speciality="Стоматолог-ортопед" },
                new Doctor {Name="Горчаков Андрей Петрович", TimeOfWork="с 8-30 до 14-00 по нечетным",TimeOfWorkSecond="с 14-30  до 20-00 по четным", ImagePath="gorchakov.jpg",Speciality="Стоматолог-терапевт" },
                new Doctor {Name="Яблонская Елена Вячеславовна", TimeOfWork=" с 14-30 до 20-00 понедельник ",TimeOfWorkSecond="с 8-30 до 14-00 четверг", ImagePath="jablonskaya.jpg",Speciality="Стоматолог-пародонтолог" },
                new Doctor {Name="Крестьян Светлана Юрьевна", TimeOfWork="В декретном отпуске",TimeOfWorkSecond="", ImagePath="krestyan.jpg",Speciality="Стоматолог" },               
            };
            Label header = new Label
            {
                Text = "Список врачей",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };
            ListView listView = new ListView
            {
                HasUnevenRows = true,
                ItemsSource = Doctors,
                // Определяем формат отображения данных
                ItemTemplate = new DataTemplate(() =>
                {
                    ImageCell imageCell = new ImageCell { TextColor = Color.DarkBlue, DetailColor = Color.Green };
                    imageCell.SetBinding(ImageCell.TextProperty, "Name");
                    Binding companyBinding = new Binding { Path = "Speciality", StringFormat = "{0}" };
                    imageCell.SetBinding(ImageCell.DetailProperty, companyBinding);
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "ImagePath");
                    return imageCell;
                })
            };
            listView.ItemTapped += OnItemTapped;
            this.Content = new StackLayout { Children = { header, listView } };
        }
        public async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            Doctor selectedDoctor = e.Item as Doctor;
            if (selectedDoctor != null)
                await DisplayAlert("Часы приема", $"{selectedDoctor.TimeOfWork + "\n" + selectedDoctor.TimeOfWorkSecond}", "OK");                
        }
    }
    public class Doctor
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string TimeOfWork { get; set; }
        public string TimeOfWorkSecond { get; set; }
        public string Speciality { get; set; }
    }
}
