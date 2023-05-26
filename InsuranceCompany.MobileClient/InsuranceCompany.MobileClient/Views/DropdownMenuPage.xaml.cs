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
    public partial class DropdownMenuPage : ContentPage
    {
        public InsurancesViewModel insurancesViewModel { get; set; }
        private DropdownMenuViewModel viewModel { get; set; }
        public DropdownMenuPage()
        {
            InitializeComponent();
            viewModel = new DropdownMenuViewModel() 
            { 
                Navigation = this.Navigation
            };
            BindingContext = viewModel;
        }
        private void OnBackgroundTapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}