using _6251App.Filter.Base;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6251App.Filter
{
    public class SwapFilter : IFilter
    {
        public Bitmap Apply(Bitmap bmp)
        {
            Bitmap temp = new Bitmap(bmp.Width, bmp.Height);

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int x = 0; x < bmp.Height; x++)
                {
                    Color c = bmp.GetPixel(i, x);
                    Color cLayer = Color.FromArgb(c.A, c.G, c.B, c.R);
                    temp.SetPixel(i, x, cLayer);
                }
            }

            return temp;
        }

        public override string ToString()
        {
            return "Swap filter";
        }
    }
}
