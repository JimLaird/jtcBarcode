using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;

namespace jtcBarcode.ViewModels
{
    public class AboutModel : ViewModelBase
    {
        public AboutModel()
        {
            Title = "About";

            //OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));

        }

        public ICommand OpenWebCommand { get; }
    }
}
