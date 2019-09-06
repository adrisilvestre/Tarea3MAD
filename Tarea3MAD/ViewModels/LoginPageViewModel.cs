using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Tarea3MAD.Models;
using Tarea3MAD.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace Tarea3MAD.ViewModels
{
   public class LoginPageViewModel : INotifyPropertyChanged
    {
        public string MessageText { get; set; }
        public User User { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand TapRegistryCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public LoginPageViewModel()
        {
            User = new User();

            TapRegistryCommand = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new RegistryPage());
            });

            LoginCommand = new Command(async () =>
            {

                if (String.IsNullOrEmpty(User.Email) || String.IsNullOrEmpty(User.Password))
                {

                    MessageText = "No se admiten campos vacíos.";

                }
                else
                {
                    MessageText = null;
                    await App.Current.MainPage.Navigation.PushAsync(new ContactPage());
                }

            });


        }
    }
}
