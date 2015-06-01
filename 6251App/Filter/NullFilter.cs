using _6251App.Filter.Base;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6251App.Filter
{
    class NullFilter : IFilter
    {
        public Bitmap Apply(Bitmap original)
        {
            return original;
        }

        public override string ToString()
        {
            return "Without filter";
        }
    }
}
