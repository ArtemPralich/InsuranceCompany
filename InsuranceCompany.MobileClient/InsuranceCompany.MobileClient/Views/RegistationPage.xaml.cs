using InsuranceCompany.MobileClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InsuranceCompany.MobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistationPage : ContentPage
    {
        public RegistationPage()
        {

            InitializeComponent();
            BindingContext = new RegistrationViewModel() { Navigation = this.Navigation };
        }
    }
}