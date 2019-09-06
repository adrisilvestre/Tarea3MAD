using System;


using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Tarea3MAD.Models;
using Tarea3MAD.Views;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.ObjectModel;


namespace Tarea3MAD.ViewModels
{
    public class ContactPageViewModel:INotifyPropertyChanged
    {
        public Contact SelectedContact { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Contact> ContactsList { get; set; } = new ObservableCollection<Contact>();
        public ICommand DeleteElementCommand { get; set; }
        public ICommand MoreActionsCommand { get; set; }
        public ICommand AddContactCommand { get; set; }
      

        public ContactPageViewModel()
        {
            new Contact();

            AddContactCommand = new Command<Contact>(async (param) =>
              {
                  await App.Current.MainPage.Navigation.PushAsync(new AddContactPage());
                  MessagingCenter.Subscribe<AddContactPageViewModel, Contact>(this, "ContactInfo", ((sender, contactinfo) =>
                  {

                      MessagingCenter.Unsubscribe<AddContactPageViewModel, Contact>(this, "ContactInfo");
                      ContactsList.Add(contactinfo);
                              
                      
                  }));

                 
              });

            DeleteElementCommand = new Command<Contact>(async (param) =>
            {
                this.ContactsList.Remove(SelectedContact);
                
            });

            MoreActionsCommand = new Command<Contact>(async (param) =>
              {
                  var result = await App.Current.MainPage.DisplayActionSheet("More", "Cancel", null, "Call","Edit");

                  switch (result)
                  {
                      case "Call":
                          Device.OpenUri(new Uri(String.Format("tel:{0}", SelectedContact.PhoneNumber)));
                          break;
                      case "Edit":

                          EditContact(SelectedContact);
                          break;
                      default:
                          break;
                  }
              });

            MessagingCenter.Subscribe<EditContactPageViewModel, Contact>(this, "EditionFinished", ((sender, contacinfo) =>
            {
                MessagingCenter.Unsubscribe<EditContactPageViewModel, Contact>(this, "EditionFinished");

                //Solo "edita" el primer elemento.
                ContactsList.Remove(SelectedContact);
                ContactsList.Add(contacinfo);
              //  SelectedContact = contacinfo;
               // SelectedContact.Name = contacinfo.Name; Aquí como que sucede algo
                //SelectedContact.PhoneNumber = contacinfo.PhoneNumber;

                
            }));


        }

        async void CloseEditPage()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }
        void EditContact(Contact SelectedContact)
        {
            MessagingCenter.Send<ContactPageViewModel, Contact>(this, "EditContact", SelectedContact);
            App.Current.MainPage.Navigation.PushAsync(new EditContactPage());
        }

   

    }
}
