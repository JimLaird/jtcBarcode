using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace jtcBarcode.Services
{
    public interface IBarcodeService
    {
        Stream ConvertImageStream(string text, int width = 320, int height = 320);
    }
}
