using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace GraphicsWindow
{
    class CNullConverter
    {
        public CNullConverter()
        {

        }

        public System.Drawing.Bitmap Render(String Filename)
        {
            Bitmap b = new Bitmap(Filename);
            //BitmapData bd = b.LockBits(new Rectangle(0, 0, b.Width, b.Height),
             //   ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            
            return b;



        }
    }
}
