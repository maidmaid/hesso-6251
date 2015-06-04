using _6251App.Filter.Base;
using System;
using System.Drawing;

namespace _6251App.Filter
{
    class SobelFilter : ConvolutionFilter
    {
        public override double[,] XMatrix
        {
            get
            {
                return new double[,] 
                { { -1,  0,  1, }, 
                  { -2,  0,  2, }, 
                  { -1,  0,  1, }, };
            }
        }

        public override double[,] YMatrix
        {
            get
            {
                return new double[,] 
                { {  1,  2,  1, }, 
                  {  0,  0,  0, }, 
                  { -1, -2, -1, }, };
            }
        }

        public override string ToString()
        {
            return "Sobel filter (edge detection)";
        }
    }
}
