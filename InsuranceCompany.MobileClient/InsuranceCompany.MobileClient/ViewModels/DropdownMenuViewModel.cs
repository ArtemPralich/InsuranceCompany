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
        public ObservableCollection<string> MenuItems { get; set; }
        public ICommand MenuItemSelectedCommand { get; set; }

        public DropdownMenuViewModel()
        {
            MenuItems = new ObservableCollection<string>
            {
                "Menu Item 1",
                "Menu Item 2",
                "Menu Item 3"
            };

            MenuItemSelectedCommand = new Command<string>(OnMenuItemSelected);
        }

        private void OnMenuItemSelected(string selectedItem)
        {
            // Обработка выбранного пункта меню
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
