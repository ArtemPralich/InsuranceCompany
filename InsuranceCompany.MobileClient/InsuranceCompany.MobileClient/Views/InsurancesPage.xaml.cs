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
    public partial class InsurancesPage : ContentPage
    {
        private InsurancesViewModel viewModel { get; set; }
        public InsurancesPage()
        {
            InitializeComponent();
            viewModel = new InsurancesViewModel() { Navigation = this.Navigation };
            BindingContext = viewModel;
        }
        protected override async void OnAppearing()
        {
            await viewModel.GetClientInsurances();
            base.OnAppearing();
        }

    }
}