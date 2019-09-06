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
        public Contact Contact1 { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand EditCommand { get; set; }
        public ICommand EditingCommand { get; set; }
        public EditContactPageViewModel()
        {
            Contact1 = new Contact();

            MessagingCenter.Subscribe<ContactPageViewModel, Contact>(this, "EditContact", ((sender, SelectedContact) =>
            {
                MessagingCenter.Unsubscribe<ContactPageViewModel, Contact>(this, "EditContact");
                EditingCommand = new Command(async () =>
                {
                    
                    Contact1 = SelectedContact;
                    
                });
                

                
            }));

            EditCommand = new Command(async () =>
              {
                  

                  if (String.IsNullOrEmpty(Contact1.Name) || String.IsNullOrEmpty(Contact1.PhoneNumber))
                  {

                      MessageText = "No se admiten campos vacíos.";

                  }
                  else
                  {
                      MessageText = null;
                     MessagingCenter.Send<EditContactPageViewModel, Contact>(this, "EditionFinished", Contact1);

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
