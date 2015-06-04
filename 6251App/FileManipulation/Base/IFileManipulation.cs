using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6251App.FileManipulation.Base
{
    public interface IFileManipulation
    {
        Bitmap Load();
        void Save(Bitmap image);
    }
}
