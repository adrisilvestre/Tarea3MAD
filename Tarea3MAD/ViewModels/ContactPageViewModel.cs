using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using Tarea3MAD.Models;
using Tarea3MAD.Views;


namespace Tarea3MAD.ViewModels
{
    public class ContactPageViewModel
    {
        Contact contact;
        public Contact SelectedContact
        {
            get
            {
                return contact;
            }
            set
            {
                contact = value;

                if (contact != null) { OnSelectItem(contact); }
            }
        }

        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();
        public ICommand DeleteElementCommand { get; set; }
        public ICommand MoreActionsCommand { get; set; }
        public ICommand AddContactCommand { get; set; }
        
        public ContactPageViewModel()
        {
            Contact mycontact = new Contact();
            mycontact.Name = "Pablo";
            mycontact.PhoneNumber = "8201598";
            Contacts.Add(mycontact);

            AddContactCommand = new Command<Contact>(async (param) =>
              {
                  var result = await App.Current.MainPage.DisplayAlert("More", "Cancel", "Destruction", "Borrar");
                  //await App.Current.MainPage.Navigation.PushAsync(new AddContactPage());
              });

            DeleteElementCommand = new Command<Contact>(async (param) =>
            {
                var result = await App.Current.MainPage.DisplayAlert("Menu", "Cancel", "Destruction", "Borrar");
            });

            MoreActionsCommand = new Command<Contact>(async (param) =>
              {
                  var result = await App.Current.MainPage.DisplayAlert("More", "Cancel", "Destruction", "Borrar");
              });


            MessagingCenter.Subscribe<App, string>(this, "TESTID", ((sender, param) =>
            {
                MessagingCenter.Unsubscribe<App, string>(this, "TESTID");
            }));
        }

        void OnSelectItem(Contact contact)
        {
            Contact myContact = new Contact();
            myContact.Name = "New Name";

            Contacts.Add(myContact);
        }
    }
}
