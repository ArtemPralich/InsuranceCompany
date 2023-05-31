using InsuranceCompany.MobileClient.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace InsuranceCompany.MobileClient.ViewModels
{
    public class DropdownMenuViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }
        public ICommand LogOutCommand { get; set; }
        public ICommand GoToDocumentsCommand { get; set; }
        public ICommand GoToInsurancesCommand { get; set; }

        public InsurancesViewModel insurancesViewModel { get; set; }
        public DropdownMenuViewModel()
        {
            LogOutCommand = new Command(OnMenuItemSelected);
            GoToDocumentsCommand = new Command(GoToDocuments);
            GoToInsurancesCommand = new Command(GoToInsurances);
        }
        private void OnMenuItemSelected()
        {
            App.Current.Properties.Remove("token");
            App.Current.Properties.Remove("role");
            App.Current.SavePropertiesAsync();
            LoginPage myPage = new LoginPage();
            NavigationPage.SetHasNavigationBar(myPage, false);
            var navigationPage = new NavigationPage(myPage);
            NavigationPage.SetHasNavigationBar(navigationPage, false);
            App.Current.MainPage = navigationPage;
        }

        private void GoToDocuments()
        {
            DocumentPage myPage = new DocumentPage();
            NavigationPage.SetHasNavigationBar(myPage, false);
            var navigationPage = new NavigationPage(myPage);
            NavigationPage.SetHasNavigationBar(navigationPage, false);
            App.Current.MainPage = navigationPage;
        }

        private void GoToInsurances()
        {

            InsurancesPage myPage = new InsurancesPage();
            NavigationPage.SetHasNavigationBar(myPage, false);
            var navigationPage = new NavigationPage(myPage);
            NavigationPage.SetHasNavigationBar(navigationPage, false);
            App.Current.MainPage = navigationPage;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
