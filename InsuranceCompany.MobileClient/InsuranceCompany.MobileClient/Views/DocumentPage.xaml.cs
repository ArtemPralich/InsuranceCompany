using InsuranceCompany.MobileClient.Models;
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
    public partial class DocumentPage : ContentPage
    {
        private DocumentsViewModel viewModel { get; set; }
        public DocumentPage()
        {
            InitializeComponent();

            viewModel = new DocumentsViewModel()
            {
                Navigation = this.Navigation
            };
            BindingContext = viewModel;
        }
        protected override async void OnAppearing()
        {
            await viewModel.GetClientInsurances();
            base.OnAppearing();
        }
        private void OnItemTapped(object sender, EventArgs e)
        {
            var selectedDocument = ((sender as TapGestureRecognizer)?.CommandParameter as Document);
            if (viewModel.ItemTappedCommand.CanExecute(selectedDocument))
            {
                viewModel.ItemTappedCommand.Execute(selectedDocument);
            }
        }
        private void OnStackLayoutTapped(object sender, EventArgs e)
        {
            var selectedDocument = (sender as StackLayout)?.BindingContext as Document;
            if (viewModel.ItemTappedCommand.CanExecute(selectedDocument))
            {
                viewModel.ItemTappedCommand.Execute(selectedDocument);
            }
        }
    }
}