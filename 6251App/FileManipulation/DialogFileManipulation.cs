using _6251App.FileManipulation.Base;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6251App.FileManipulation
{
    class DialogFileManipulation : IFileManipulation
    {
        public Bitmap Load()
        {
            OpenFileDialog op = new OpenFileDialog();
            DialogResult dr = op.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string path = op.FileName;
                Bitmap image = new Bitmap(path);
                return image;
            }

            return null;
        }

        public void Save(Bitmap image)
        {
            throw new NotImplementedException();
        }
    }
}
