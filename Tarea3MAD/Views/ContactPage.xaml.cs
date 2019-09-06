using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Tarea3MAD.Models;
using Tarea3MAD.ViewModels;

namespace Tarea3MAD.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactPage : ContentPage
    {
        public ContactPage()
        {
            InitializeComponent();
            BindingContext = new ContactPageViewModel();

            contlistv.ItemTapped += ContListV_ItemTapped;
        }

        private void ContListV_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            MessagingCenter.Send<ContactPage, string>(this, "STUDENTID", "HELLO");
        }
    }
}