using _6251App.Filter.Base;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6251App.Filter
{
    class RainbowFilter : IFilter
    {
        public Bitmap Apply(Bitmap original)
        {
            Bitmap temp = new Bitmap(original.Width, original.Height);
            int raz = original.Height / 4;
            for (int i = 0; i < original.Width; i++)
            {
                for (int x = 0; x < original.Height; x++)
                {

                    if (i < (raz))
                    {
                        temp.SetPixel(i, x, Color.FromArgb(original.GetPixel(i, x).R / 5, original.GetPixel(i, x).G, original.GetPixel(i, x).B));
                    }
                    else if (i < (raz * 2))
                    {
                        temp.SetPixel(i, x, Color.FromArgb(original.GetPixel(i, x).R, original.GetPixel(i, x).G / 5, original.GetPixel(i, x).B));
                    }
                    else if (i < (raz * 3))
                    {
                        temp.SetPixel(i, x, Color.FromArgb(original.GetPixel(i, x).R, original.GetPixel(i, x).G, original.GetPixel(i, x).B / 5));
                    }
                    else if (i < (raz * 4))
                    {
                        temp.SetPixel(i, x, Color.FromArgb(original.GetPixel(i, x).R / 5, original.GetPixel(i, x).G, original.GetPixel(i, x).B / 5));
                    }
                    else
                    {
                        temp.SetPixel(i, x, Color.FromArgb(original.GetPixel(i, x).R / 5, original.GetPixel(i, x).G / 5, original.GetPixel(i, x).B / 5));
                    }
                }

            }
            return temp;
        }

        public override string ToString()
        {
            return "Rainbow filter";
        }
    }
}
