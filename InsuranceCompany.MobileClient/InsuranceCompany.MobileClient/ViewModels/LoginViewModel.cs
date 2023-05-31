using InsuranceCompany.MobileClient.Models;
using InsuranceCompany.MobileClient.Services;
using InsuranceCompany.MobileClient.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace InsuranceCompany.MobileClient.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }
        public NavigationPage ThisPage { get; set; }
        AuthService authService = new AuthService();
        User user;

        public string Email
        {
            get { return user.Email; }
            set
            {
                user.Email = value;
                OnPropertyChanged("Email");
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
        private bool _isIncorrectly;
        public bool IsIncorrectly
        {
            get { return _isIncorrectly; }
            set
            {
                _isIncorrectly = value;
                OnPropertyChanged("IsIncorrectly");
            }
        }


        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged("IsBusy");
            }
        }

        public ICommand SignInCommand { protected set; get; }
        public ICommand GoToRegistrationCommand { protected set; get; }
        public ICommand GoToForgotPasswordCommand { protected set; get; }

        public LoginViewModel()
        {
            user = new User() { Email = "", Password = ""};
            SignInCommand = new Command(async () => await SignIn());
            GoToRegistrationCommand = new Command(GoToRegistration);
            GoToForgotPasswordCommand = new Command(GoToForgotPassword);

        }

        private async Task SignIn()
        {
            IsBusy = true;
            var a = await authService.Login(user);
            if (a != null)
            {
                IsBusy = false;
                IsIncorrectly = false;
                if (App.Current.Properties.TryGetValue("token", out object buff))
                {
                    if (buff != null)
                    {

                        App.Current.Properties.Remove("token"); 
                    }
                }
                if (App.Current.Properties.TryGetValue("role", out object buff1))
                {
                    if (buff1 != null)
                    {

                        App.Current.Properties.Remove("role");
                    }
                }

                App.Current.SavePropertiesAsync();
                App.Current.Properties.Add("token", a.Token);
                App.Current.Properties.Add("role", a.Role);

                App.Current.SavePropertiesAsync();

                Application.Current.MainPage.Navigation.PushAsync(new InsurancesPage()); 
            }
            else
            {
                IsBusy = false;
                IsIncorrectly = true;
            }
        }

        private void GoToRegistration()
        {
            Application.Current.MainPage.Navigation.PushAsync(new RegistationPage());
        }

        private void GoToForgotPassword()
        {
            ForgotPasswordPage overlayPage = new ForgotPasswordPage();
            //overlayPage.BackgroundColor = Color.Transparent;
            Navigation.PushModalAsync(overlayPage, false);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
