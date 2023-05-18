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
    public partial class DropdownMenuPage : ContentPage
    {
        public DropdownMenuPage()
        {
            InitializeComponent();
        }
        private void OnBackgroundTapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}