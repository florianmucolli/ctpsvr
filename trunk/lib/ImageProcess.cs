using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Citiport.Photo.Process
{
    public class ImageProcess
    {
        Bitmap Zoom(double ratio, Bitmap btmp)
        {
            int w = Convert.ToInt32(btmp.Width * ratio);
            int h = Convert.ToInt32(btmp.Height * ratio);
            Bitmap resizedBmp = new Bitmap(w, h);
            Graphics g = Graphics.FromImage(resizedBmp);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;           //平滑消鋸齒
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.DrawImage(btmp, new Rectangle(0, 0, w, h), new Rectangle(0, 0, btmp.Width, btmp.Height), GraphicsUnit.Pixel);
            g.Dispose();
            return resizedBmp;
        }

        Bitmap Sharpen(Bitmap btmp)
        {
            int r, g, b;
            for (int x = 1; x < btmp.Width - 1; x++)
            {
                for (int y = 1; y < btmp.Height - 1; y++)
                {
                    Color c = btmp.GetPixel(x, y);
                    Color c1 = btmp.GetPixel(x - 1, y - 1);
                    r = c.R + ((c.R - c1.R) / 2);
                    g = c.G + ((c.G - c1.G) / 2);
                    b = c.B + ((c.B - c1.B) / 2);
                    if (r > 255) r = 255;
                    if (r < 0) r = 0;
                    if (g > 255) g = 255;
                    if (g < 0) g = 0;
                    if (b > 255) b = 255;
                    if (b < 0) b = 0;
                    btmp.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            return btmp;
        }

        Bitmap Equalization(int value, Bitmap btmp)
        {
            double[] gray_level = new double[256];
            int[, ,] rgbData = new int[btmp.Width, btmp.Height, 3];

            for (int j = 0; j < 256; j++)
            {
                gray_level[j] = 0;
            }
            for (int x = 0; x < btmp.Height; x++) //讀取像素迴圈
            {
                for (int y = 0; y < btmp.Width; y++)
                {
                    Color c = btmp.GetPixel(y, x);
                    rgbData[y, x, 0] = c.R;
                    rgbData[y, x, 1] = c.G;
                    rgbData[y, x, 2] = c.B;
                    int gray = (rgbData[y, x, 0] + rgbData[y, x, 1] + rgbData[y, x, 2]) / 3;
                    gray_level[gray]++;
                }
            }
            int v = btmp.Height * btmp.Width;

            for (int j = 0; j < 256; j++) //各像素的機率值
            {
                gray_level[j] = gray_level[j] / v;
            }

            for (int j = 1; j < 256; j++) //前面項機率累加
            {
                gray_level[j] = gray_level[j] + gray_level[j - 1];
            }
            int kk = value;
            for (int j = 0; j < 256; j++) //新機率值乘255
            {
                gray_level[j] = gray_level[j] * (255 - kk);
            }

            for (int k = 0; k < btmp.Height; k++)
            {
                for (int u = 0; u < btmp.Width; u++)
                {
                    rgbData[u, k, 0] = System.Convert.ToInt32(gray_level[rgbData[u, k, 0]]);
                    rgbData[u, k, 1] = System.Convert.ToInt32(gray_level[rgbData[u, k, 1]]);
                    rgbData[u, k, 2] = System.Convert.ToInt32(gray_level[rgbData[u, k, 2]]);
                    btmp.SetPixel(u, k, Color.FromArgb(rgbData[u, k, 0], rgbData[u, k, 1], rgbData[u, k, 2]));
                }
            }
            return btmp;
        }
    }
}
