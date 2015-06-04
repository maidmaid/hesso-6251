using _6251App.Filter.Base;
using System;
using System.Drawing;

namespace _6251App.Filter
{
    class LaplacianFilter : ConvolutionFilter
    {
        public override double[,] XMatrix
        {
            get
            {
                return new double[,]  
                { { -1, -1, -1,  }, 
                  { -1,  8, -1,  }, 
                  { -1, -1, -1,  }, };
            }
        }

        public override string ToString()
        {
            return "Laplacian filter (edge detection)";
        }
    }
}
