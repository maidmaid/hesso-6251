using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _6251App.Filter.Base;
using _6251App.Filter;
using _6251App.FileManipulation;
using _6251App.FileManipulation.Base;

namespace _6251App
{
    public partial class App : Form
    {
        public IFileManipulation manipuler;
        public IFilter filter;
        private Image original;
        private Bitmap filtered;

        public App()
        {
            InitializeComponent();
            manipuler = new DialogFileManipulation();
            cmbEdgeDetection.Items.Add(new NullFilter());
            cmbEdgeDetection.Items.Add(new RainbowFilter());
            cmbEdgeDetection.Items.Add(new SwapFilter());
        }

        public void btnOpenOriginal_Click(object sender, EventArgs e)
        {
            Bitmap image = manipuler.Load();
            
            if (image != null)
            {
                picPreview.Image = image;
                original = picPreview.Image;
            }
        }

        public void cmbEdgeDetection_SelectedIndexChanged(object sender, EventArgs e)
        {
            filter = (IFilter)cmbEdgeDetection.SelectedItem;
            Bitmap temp = new Bitmap(original, new Size(picPreview.Width, picPreview.Height));
            filtered = filter.Apply(temp);
            picPreview.Image = filtered;
        }

        public void btnSaveNewImage_Click(object sender, EventArgs e)
        {
            manipuler.Save(filtered);
        }
    }
}
