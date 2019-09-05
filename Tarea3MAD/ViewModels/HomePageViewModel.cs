using System;
using System.Collections.Generic;
using System.Text;
using Tarea3MAD.Views;
using System.Windows.Input;
using Xamarin.Forms;
using Tarea3MAD.Models;
using System.ComponentModel;
namespace Tarea3MAD.ViewModels
{
    class HomePageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string WelcomeLabel { get; set; }
        public HomePageViewModel(User user)
        {
            WelcomeLabel = $"Welcome {user.Name}, this is DounApp Bakery Shop!";
        }
    }
}
