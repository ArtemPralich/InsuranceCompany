using InsuranceCompany.MobileClient.Models;
using InsuranceCompany.MobileClient.Services;
using InsuranceCompany.MobileClient.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace InsuranceCompany.MobileClient.ViewModels
{

    public class RegistrationViewModel
    {
        public INavigation Navigation { get; set; }
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
                _confirmPassword = value;
                OnPropertyChanged("ConfirmPassword");
            }
        }

        public ICommand GoToLoginCommand { protected set; get; }

        public RegistrationViewModel()
        {
            user = new User() { Email = "", Password = "" };
            GoToLoginCommand = new Command(GoToLogin);
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
