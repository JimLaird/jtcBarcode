using System;
using System.Collections.Generic;
using System.Text;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using jtcBarcode.Views;
using ZXing.Mobile;
using ZXing.Common;
using System.IO;
using jtcBarcode.Services;

namespace jtcBarcode.ViewModels
{
    public class CreateModel : ViewModelBase
    {
        private string barcodeVal;
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

        
        public CreateModel()
        {
            Title = "Create Barcode";

            ShareCommand = new AsyncCommand(DoShare);
            
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
