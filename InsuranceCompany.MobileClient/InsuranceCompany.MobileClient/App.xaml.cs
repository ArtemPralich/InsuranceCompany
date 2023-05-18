using InsuranceCompany.MobileClient.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InsuranceCompany.MobileClient
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            if (App.Current.Properties.TryGetValue("token", out object buff))
            {
            
                InsurancesPage myPage = new InsurancesPage();
                NavigationPage.SetHasNavigationBar(myPage, false);
                var navigationPage = new NavigationPage(myPage);
                NavigationPage.SetHasNavigationBar(navigationPage, false);
                MainPage = navigationPage;
            }
            else
            {

                LoginPage myPage = new LoginPage();
                NavigationPage.SetHasNavigationBar(myPage, false);
                var navigationPage = new NavigationPage(myPage);
                NavigationPage.SetHasNavigationBar(navigationPage, false);
                MainPage = navigationPage;

            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
