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
            
            // add filters to combobox
            cmbEdgeDetection.Items.Add(new NullFilter());
            cmbEdgeDetection.Items.Add(new RainbowFilter());
            cmbEdgeDetection.Items.Add(new SwapFilter());
            cmbEdgeDetection.Items.Add(new LaplacianFilter());
            cmbEdgeDetection.Items.Add(new SobelFilter());
        }

        /// <summary>
        /// Load a bitmap from the disk, display it in the picturebox and keep an instance
        /// as the original picture
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnOpenOriginal_Click(object sender, EventArgs e)
        {
            Bitmap image = manipuler.Load();
            
            if (image != null)
            {
                // enable UI components when image loaded
                cmbEdgeDetection.Enabled = true;
                btnSaveNewImage.Enabled = true;
                
                picPreview.Image = image;
                original = picPreview.Image;
            }
        }

        /// <summary>
        /// Create a temporary picture from the original then apply filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void cmbEdgeDetection_SelectedIndexChanged(object sender, EventArgs e)
        {
            filter = (IFilter)cmbEdgeDetection.SelectedItem;
            Bitmap temp = new Bitmap(original, new Size(original.Width, original.Height));
            filtered = filter.Apply(temp);
            picPreview.Image = filtered;
        }

        /// <summary>
        /// Save filtered image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnSaveNewImage_Click(object sender, EventArgs e)
        {
            manipuler.Save(filtered);
        }
    }
}
