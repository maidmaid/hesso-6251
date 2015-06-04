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
    public class DialogFileManipulation : IFileManipulation
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
            // don't save the image if it's the original or if null
            if (image != null)
            {
                FolderBrowserDialog fl = new FolderBrowserDialog();
                if (fl.ShowDialog() != DialogResult.Cancel)
                {
                    image.Save(fl.SelectedPath + @"\filtered.png", System.Drawing.Imaging.ImageFormat.Png);
                }
            }
        }
    }
}
