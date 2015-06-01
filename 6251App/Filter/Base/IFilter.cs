using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6251App.Filter.Base
{
    interface IFilter
    {
        Bitmap Apply(Bitmap original);
    }
}
