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
    public class EditContactPageViewModel:INotifyPropertyChanged
    {
        public string MessageText { get; set; }
        public Contact Contact { get; set; }
        public ICommand EditCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public EditContactPageViewModel()
        {
            Contact = new Contact();

            MessagingCenter.Subscribe<ContactPageViewModel, Contact>(this, "EditContact", ((sender, SelectedContact) =>
            {
                MessagingCenter.Unsubscribe<ContactPageViewModel, Contact>(this, "EditContact");
                Contact.Name = SelectedContact.Name;
                Contact.PhoneNumber = SelectedContact.PhoneNumber;

                
            }));

            EditCommand = new Command(async () =>
              {
                  

                  if (String.IsNullOrEmpty(Contact.Name) || String.IsNullOrEmpty(Contact.PhoneNumber))
                  {

                      MessageText = "No se admiten campos vacíos.";

                  }
                  else
                  {
                      MessageText = null;
                      MessagingCenter.Send<EditContactPageViewModel, Contact>(this, "EditionFinished", Contact);

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
