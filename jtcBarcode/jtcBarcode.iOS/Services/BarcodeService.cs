using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using System.Drawing;
using System.IO;
using Xamarin.Forms;
using jtcBarcode.Services;
using CoreGraphics;
using ZXing.Mobile;

[assembly: Dependency(typeof(jtcBarcode.iOS.BarcodeService))]
namespace jtcBarcode.iOS
{
    public class BarcodeService : IBarcodeService
    {
        public Stream ConvertImageStream (string text, int width=320, int height = 320)
        {
            var barcodeWriter = new ZXing.Mobile.BarcodeWriter
            {
                Format = ZXing.BarcodeFormat.QR_CODE,
                Options = new ZXing.Common.EncodingOptions
                {
                    Width = width,
                    Height = height,
                    Margin = 10
                }
            };

            barcodeWriter.Renderer = new ZXing.Mobile.BitmapRenderer();
            var bitmap = barcodeWriter.Write(text);
            var stream = bitmap.AsPNG().AsStream(); //  iOS Implementation
            stream.Position = 0;

            return stream;
        }
    }
}