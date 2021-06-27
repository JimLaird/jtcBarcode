using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace jtcBarcode.Services
{
    public interface IBarcodeService
    {
        Stream ConvertImageStream(string text, int width = 320, int height = 320);
        
    }
}
