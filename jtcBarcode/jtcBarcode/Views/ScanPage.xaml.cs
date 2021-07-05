using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace jtcBarcode.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScanPage : ContentPage
    {
        public ScanPage()
        {
            InitializeComponent();
        }

        void ZXingScannerView_OnScanResult(ZXing.Result result)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (result != null)
                    txtResult.Text = result.Text;

                //  Check if the result is text string, email address or URI

                if (RegExUtilites.IsValidEmail(result.Text))
                {
                    //  Launch email client
                    btnAction.Text = "Open Email";
                }
                else if (RegExUtilites.IsValidUrl(result.Text))
                {
                    //  Launch browser
                    btnAction.Text = "Open Browser";
                }
                else
                {
                    //  Just text string
                    btnAction.IsEnabled = false;
                }
            });
        }
    }
}