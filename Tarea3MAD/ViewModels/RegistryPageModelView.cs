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
    public class RegistryPageModelView:INotifyPropertyChanged
    {
        public string MessageText { get; set; }
        public User NewUser { get; set; }
        public ICommand RegisterCommand { get; set; }

        private const string Pattern = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        public event PropertyChangedEventHandler PropertyChanged;
        // public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public RegistryPageModelView()
        {
            NewUser = new User();

            RegisterCommand = new Command(async () =>
            {
                bool prob = false; //problem

                if (String.IsNullOrEmpty(NewUser.Name) || String.IsNullOrEmpty(NewUser.Email)
                      || String.IsNullOrEmpty(NewUser.Password) || String.IsNullOrEmpty(NewUser.ConfPassword))
                {
                    MessageText = "No se admiten entradas vacías";
                    prob = true;
                }

                if (prob == false)
                {
                    if (!Regex.IsMatch(NewUser.Email, Pattern))
                    {
                        MessageText = "El correo electrónico no es válido";
                        prob = true;
                    }

                    if (!NewUser.Password.Equals(NewUser.ConfPassword))
                    {
                        MessageText = "Las contraseñas no coinciden";
                        prob = true;
                    }

                }

                if (prob == false)
                {
                    //MessageText = "Excelente";
                    await App.Current.MainPage.Navigation.PushAsync(new HomePage(NewUser));
                }
            });
        }
    }
}
