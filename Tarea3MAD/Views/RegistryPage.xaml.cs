using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea3MAD.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tarea3MAD.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistryPage : ContentPage
    {
        public RegistryPage()
        {
            InitializeComponent();
            BindingContext = new RegistryPageModelView();
        }
    }
}