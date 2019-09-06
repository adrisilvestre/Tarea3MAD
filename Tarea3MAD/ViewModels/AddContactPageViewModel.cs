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
        public Contact contact { get; set; }
        public ICommand AddCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public AddContactPageViewModel()
        {
            contact = new Contact();

            AddCommand = new Command(async () =>
              {
                  if (String.IsNullOrEmpty(contact.Name) || String.IsNullOrEmpty(contact.PhoneNumber))
                  {

                      MessageText = "No se admiten campos vacíos.";

                  }
                  else
                  {
                      MessageText = null;
                     
                  }
              });
        }

    }
}
