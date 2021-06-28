using System;
using System.Collections.Generic;
using System.Text;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Xamarin.Forms;
using Xamarin.Essentials;

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
        public ScanModel()
        {
            Title = "Scan QR Code";

        }
    }
}
