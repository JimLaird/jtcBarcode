﻿using System;
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

namespace jtcBarcode.ViewModels
{
    public class MainModel : ViewModelBase
    {
        private string barcodeVal;
        public AsyncCommand AboutCommand { get; }
        public AsyncCommand SettingsCommand { get; }
        public AsyncCommand ShareCommand { get; }

        public string BarcodeVal
        {
            get => barcodeVal;
            set
            {
                SetProperty(ref barcodeVal, value);
                OnPropertyChanged();
            }
        }

        public MainModel()
        {
            Title = "jtcBarcode";

            AboutCommand = new AsyncCommand(GoAbout);
            SettingsCommand = new AsyncCommand(GoSettings);
            ShareCommand = new AsyncCommand(DoShare);
        }

        private async Task GoAbout()
        {
            //
            App.Current.MainPage.Navigation.PushAsync(new AboutPage());
        }

        private async Task GoSettings()
        {
            //
            App.Current.MainPage.Navigation.PushAsync(new SettingsPage());
        }

        private async Task DoShare()
        {
            
            ZXing.BarcodeWriterSvg barcodeWriter = new ZXing.BarcodeWriterSvg
            {
                Format = ZXing.BarcodeFormat.QR_CODE
            };

            var bcode = BarcodeVal;
            barcodeWriter.Write(bcode);

            await Share.RequestAsync(new ShareTextRequest
            {
                Text = bcode,
                Title = "Share !"
            });
        }
    }
}