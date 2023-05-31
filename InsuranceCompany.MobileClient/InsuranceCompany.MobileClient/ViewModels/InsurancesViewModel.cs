using InsuranceCompany.MobileClient.Models;
using InsuranceCompany.MobileClient.Services;
using InsuranceCompany.MobileClient.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace InsuranceCompany.MobileClient.ViewModels
{
    public class ListItem : INotifyPropertyChanged
    {
        private double _height;
        public InsuranceRequest Item { get; set; }
        public double Height
        {
            get { return _height; }
            set
            {
                if (_height != value)
                {
                    _height = value;
                    OnPropertyChanged(nameof(Height)); // Уведомление об изменении свойства
                }
            }
        }

        // Реализация интерфейса INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public bool _isOpen = false;
        public bool IsOpen 
        {
            get { return _isOpen; }
            set
            {
                if (_isOpen != value)
                {
                    _isOpen = value;
                    OnPropertyChanged(nameof(IsOpen)); // Уведомление об изменении свойства
                }
            }
        }
        public ICommand ItemTappedCommand { get; set; }
    }
    public class InsurancesViewModel : INotifyPropertyChanged
    {
        ObservableCollection<ListItem> _insuranceRequests;
        public ObservableCollection<ListItem> InsuranceRequests
        {
            get => _insuranceRequests;
            set
            {
                _insuranceRequests = value;
                OnPropertyChanged("InsuranceRequests"); // Если ваша ViewModel реализует INotifyPropertyChanged
            }
        }
        public INavigation Navigation { get; set; }
        InsuranceRequestService insuranceRequestService { get; set; }

        public InsurancesViewModel()
        {
            insuranceRequestService = new InsuranceRequestService();
            ItemTappedCommand = new Command<ListItem>(OnItemTapped);
            ToggleMenuCommand = new Command(ToggleMenu);
            PopCommand = new Command(Pop);
            MenuWidthRequest = 250;
        }
        public async Task GetClientInsurances()
        {
            var insuranceRequestsList = new ObservableCollection<ListItem>();
            var insuranceRequests = new ObservableCollection<InsuranceRequest>(await insuranceRequestService.GetClientInsurances());
            foreach(var ins in insuranceRequests)
            {
                insuranceRequestsList.Add(new ListItem()
                {
                    Item = ins,
                    Height = 100,
                    IsOpen = false,
                    ItemTappedCommand = new Command<ListItem>(OnItemTapped)
                });
            }
            InsuranceRequests = insuranceRequestsList;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public ICommand PopCommand { get; private set; }
        private void Pop()
        {
            Application.Current.MainPage.Navigation.PopAsync();
        }

        public ICommand ItemTappedCommand { get; private set; }
        private void OnItemTapped(ListItem item)
        {
            if (item.IsOpen)
            {
                item.Height -= 90;
            }
            else
            {
                item.Height += 90;
            }
            item.IsOpen = !item.IsOpen;
        }


        private bool isMenuVisible;
        public bool IsMenuVisible
        {
            get { return isMenuVisible; }
            set 
            {
                isMenuVisible = value;
                OnPropertyChanged("IsMenuVisible");
            }
        }

        private int menuWidthRequest;
        public int MenuWidthRequest
        {
            get { return menuWidthRequest; }
            set 
            { 
                menuWidthRequest = value;
                OnPropertyChanged("MenuWidthRequest");
            }
        }

        public ICommand ToggleMenuCommand { get; }


        private void ToggleMenu()
        {
            IsMenuVisible = !IsMenuVisible;
            DropdownMenuPage overlayPage = new DropdownMenuPage();
            //overlayPage.BackgroundColor = Color.Transparent;
            Navigation.PushModalAsync(overlayPage, false);
        }
    }
}
