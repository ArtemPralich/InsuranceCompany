using InsuranceCompany.MobileClient.Services;
using InsuranceCompany.MobileClient.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace InsuranceCompany.MobileClient.ViewModels
{
    public class ForgotPasswordViewModel : INotifyPropertyChanged
    {
        public string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }
        public int _state;
        public int State
        {
            get { return _state; }
            set
            {
                _state = value;
                OnPropertyChanged("State");
                OnPropertyChanged("IsNormal");
                OnPropertyChanged("IsIncorrectly");
                OnPropertyChanged("IsOk");
            }
        }
        public bool IsNormal
        {
            get { return _state != 1; }
            set
            {

            }
        }

        public bool IsIncorrectly
        {
            get { return _state == -1; }
            set
            {
                
            }
        }

        public bool IsOk
        {
            get { return _state == 1; }
            set
            {

            }
        }

        AuthService authService = new AuthService();
        public ForgotPasswordViewModel()
        {
            RecoveryCommand = new Command(async () => await Recovery());
        }
        public INavigation Navigation { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public ICommand RecoveryCommand { protected set; get; }
        private async Task Recovery()
        {
            var a = await authService.ResetPassword(Email);
            if(a == HttpStatusCode.NoContent)
            {
                State = 1;
            }
            else
            {
                State = -1;
            }
        }
    }
}
