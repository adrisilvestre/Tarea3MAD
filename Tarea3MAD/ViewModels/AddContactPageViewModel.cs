using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Text.RegularExpressions;
using Tarea3MAD.Models;
using Tarea3MAD.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace Tarea3MAD.ViewModels
{
    public class AddContactPageViewModel:INotifyPropertyChanged
    {
        public string MessageText { get; set; }
        public Contact Contact { get; set; }
        public ICommand AddCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public AddContactPageViewModel()
        {
            Contact = new Contact();

            AddCommand = new Command(async () =>
              {
                  if (String.IsNullOrEmpty(Contact.Name) || String.IsNullOrEmpty(Contact.PhoneNumber))
                  {

                      MessageText = "No se admiten campos vacíos.";
                      
                  }
                  else
                  {
                      MessageText = null;
                      MessagingCenter.Send<AddContactPageViewModel, Contact>(this, "ContactInfo", Contact);
                      ClosePage();
                  }
              });
        }


        async void ClosePage()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }
        

    }
}
