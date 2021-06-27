using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Xamarin.Forms;
using Xamarin.Essentials;
using jtcBarcode.Views;
using ZXing.Mobile;
using ZXing.Common;
using System.IO;
using jtcBarcode.Services;



namespace jtcBarcode.ViewModels
{
    public class MainModel : ViewModelBase
    {
        private string barcodeVal;
        public AsyncCommand AboutCommand { get; }
        public AsyncCommand SettingsCommand { get; }
        public AsyncCommand ShareCommand { get; }

        public AsyncCommand PrintCommand { get; }

        public string BarcodeVal
        {
            get => barcodeVal;
            set
            {
                SetProperty(ref barcodeVal, value);
                OnPropertyChanged();
            }
        }

        private bool isScanning;
        public bool IsScanning
        {
            get => isScanning;
            set
            {
                SetProperty(ref isScanning, value);
                OnPropertyChanged();
            }
        }

        private bool isTorchOn;
        public bool IsTorchOn
        {
            get => isTorchOn;
            set
            {
                SetProperty(ref isTorchOn, value);
                OnPropertyChanged();
            }
        }

        public MainModel()
        {
            Title = "jtcBarcode";

            AboutCommand = new AsyncCommand(GoAbout);
            SettingsCommand = new AsyncCommand(GoSettings);
            ShareCommand = new AsyncCommand(DoShare);
            PrintCommand = new AsyncCommand(DoPrint);

            IsScanning = false;
            IsTorchOn = false;
        }

        private async Task GoAbout()
        {
            //
            await App.Current.MainPage.Navigation.PushAsync(new AboutPage());
        }

        private async Task GoSettings()
        {
            //
            await App.Current.MainPage.Navigation.PushAsync(new SettingsPage());
        }

        private async Task DoPrint()
        {
            //  Print the barcode
            await App.Current.MainPage.DisplayAlert("Future Feature", "Printing will be enabled in a future release", "OK");
        }

        private async Task DoShare()
        {
            //  Share the barcode
            var bcode = BarcodeVal;


            //  Call dependency service to create image stream in memory
            IBarcodeService service = DependencyService.Get<IBarcodeService>();
            Stream stream = service.ConvertImageStream(bcode, 320, 320);
            

            //  define filename
            var dt = DateTime.Now.ToString("yyyy-MM-dd-HH-mm");
            string fileName = Path.Combine(FileSystem.AppDataDirectory, dt + ".png");

            //  Copy memorystream to a filestream object
            using (var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                await stream.CopyToAsync(fileStream);
            }

            await Share.RequestAsync(new ShareFileRequest
            {
                Title = "Share QR Code",
                File = new ShareFile(fileName)
            });
        }

        
    }
}
