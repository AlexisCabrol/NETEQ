using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.models;

namespace Videotheque.utils
{
    class FileUtils
    {
        public static byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }

        public static OpenFileDialog InitOpenFileDialog()
        {
            return new OpenFileDialog
            {
                InitialDirectory = "c:\\",
                Filter = "Pictures (*.jpg;*.jpeg;*.gif;*.png)|*.jpg;*.jpeg;*.gif;*.png",
                FilterIndex = 1,
                Multiselect = false
            };
        }
    }
}
