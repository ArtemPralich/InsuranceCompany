using InsuranceCompany.MobileClient.Models;
using InsuranceCompany.MobileClient.Services;
using InsuranceCompany.MobileClient.Views;
using Plugin.XamarinFormsSaveOpenPDFPackage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms;
using static Xamarin.Essentials.AppleSignInAuthenticator;

namespace InsuranceCompany.MobileClient.ViewModels
{
    public class DocumentsViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }
        public DocumentsViewModel()
        {
            insuranceRequestService = new InsuranceRequestService();
            ToggleMenuCommand = new Command(ToggleMenu);
            ItemTappedCommand = new Command<Document>(async (item) => await DownloadFile(item));
        }

        ObservableCollection<Document> _insuranceDocuments;
        public ObservableCollection<Document> InsuranceDocuments
        {
            get => _insuranceDocuments;
            set
            {
                _insuranceDocuments = value;
                OnPropertyChanged("InsuranceDocuments");
            }
        }
        InsuranceRequestService insuranceRequestService { get; set; }

        public ICommand ToggleMenuCommand { get; }
        public ICommand ItemTappedCommand { get; }
        public bool isMenuVisible;
        public bool IsMenuVisible
        {
            get { return isMenuVisible; }
            set
            {
                isMenuVisible = value;
                OnPropertyChanged("IsMenuVisible");
            }
        }
        public async Task DownloadFileFromServer(string url, string filePath)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    using (Stream stream = await response.Content.ReadAsStreamAsync())
                    {
                        using (FileStream fileStream = File.Create(filePath))
                        {
                            stream.CopyTo(fileStream);
                        }
                    }
                }
            }
        }
        private async Task DownloadFile(Document document)
        {
            HttpClientHandler clientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            };

            var url = "https://10.0.2.2:7046/Document/GetPDF?id=" + document.Id.ToString();
            var fileName = document.Title; // задайте имя файла здесь

            using (HttpClient client = new HttpClient(clientHandler))
            {
                if (App.Current.Properties.TryGetValue("token", out object buff))
                {
                    if (buff != null)
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", buff.ToString());
                    }
                }
                var response = await client.GetStreamAsync(url);
                
                using (var memoryStream = new MemoryStream())
                {
                    await response.CopyToAsync(memoryStream);

                    //await CrossXamarinFormsSaveOpenPDFPackage.Current.SaveAndView("myFile.pdf", "application/pdf", memoryStream, PDFOpenContext.InApp);
                    await CrossXamarinFormsSaveOpenPDFPackage.Current.SaveAndView(document.Title, "application/pdf", memoryStream, PDFOpenContext.InApp);
                }
            }
        }
        private void ShowPdf(byte[] content)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var webView = new WebView();

                // Создаем HTML-страницу, встраивая содержимое PDF-файла как base64-кодированную строку
                var base64String = Convert.ToBase64String(content);
                var html = $"<html><body><object data=\"data:application/pdf;base64,{base64String}\" width=\"100%\" height=\"100%\" type=\"application/pdf\"></body></html>";

                webView.Source = new HtmlWebViewSource { Html = html };
                webView.HeightRequest = 500;
                // Открываем новую страницу с WebView
                App.Current.MainPage.Navigation.PushAsync(new ContentPage { Content = webView });
            });
        }

        private void ToggleMenu()
        {
            IsMenuVisible = !IsMenuVisible;
            DropdownMenuPage overlayPage = new DropdownMenuPage();
            //overlayPage.BackgroundColor = Color.Transparent;
            Navigation.PushModalAsync(overlayPage, false);
        }

        public async Task GetClientInsurances()
        {
            var insuranceDocuments = new ObservableCollection<Document>();
            var insuranceRequests = new ObservableCollection<InsuranceRequest>(await insuranceRequestService.GetClientInsurances());
            foreach (var ins in insuranceRequests)
            {
                foreach(var doc in ins.Documents)
                {
                    insuranceDocuments.Add(doc);
                }
            }
            InsuranceDocuments = insuranceDocuments;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
