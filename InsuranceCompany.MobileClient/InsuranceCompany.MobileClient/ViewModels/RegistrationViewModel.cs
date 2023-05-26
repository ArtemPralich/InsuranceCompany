using InsuranceCompany.MobileClient.Models;
using InsuranceCompany.MobileClient.Services;
using InsuranceCompany.MobileClient.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace InsuranceCompany.MobileClient.ViewModels
{

    public class RegistrationViewModel
    {
        public INavigation Navigation { get; set; }
        AuthService authService = new AuthService();
        RegistrationUser user;
        public string Email
        {
            get { return user.Email; }
            set
            {
                user.Email = value;
                OnPropertyChanged("Email");
            }
        }
        public string UserName
        {
            get { return user.UserName; }
            set
            {
                user.Email = value;
                OnPropertyChanged("UserName");
            }
        }
        public string Password
        {
            get { return user.Password; }
            set
            {
                user.Password = value;
                OnPropertyChanged("Password");
            }
        }

        private string _confirmPassword { get; set; }
        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                user.ConfirmPassword = value;
                OnPropertyChanged("ConfirmPassword");
            }
        }

        public ICommand GoToLoginCommand { protected set; get; }
        public ICommand RegitrationCommand { protected set; get; }

        public RegistrationViewModel()
        {
            user = new RegistrationUser() { Email = "", Password = "", ConfirmPassword = "", UserName = "" };
            GoToLoginCommand = new Command(GoToLogin);
            RegitrationCommand = new Command( async () => await Registration());
        }
        private async Task Registration()
        {
            var a = await authService.Regitration(user);
            if (a != null)
            {
                App.Current.Properties.Add("token", a.Token);
                App.Current.Properties.Add("role", "Client");
                App.Current.SavePropertiesAsync();

                Application.Current.MainPage.Navigation.PushAsync(new InsurancesPage());
            }
        }
        private void GoToLogin()
        {
            Application.Current.MainPage.Navigation.PopAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
