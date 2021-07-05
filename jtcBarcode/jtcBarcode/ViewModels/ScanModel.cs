using System;
using System.Collections.Generic;
using System.Text;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;

namespace jtcBarcode.ViewModels
{
    public class ScanModel :ViewModelBase
    {
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

        private string barcodeVal;
        public string BarcodeVal
        {
            get => barcodeVal;
            set
            {
                SetProperty(ref barcodeVal, value);
                OnPropertyChanged();
            }
        }
        public AsyncCommand CopyCommand { get; }

        public ScanModel()
        {
            Title = "Scan QR Code";

            CopyCommand = new AsyncCommand(DoCopy);
        }

        async Task DoCopy()
        {
            await Clipboard.SetTextAsync(BarcodeVal);
            await App.Current.MainPage.DisplayToastAsync("Copied to clipboard");
        }
    }
}
