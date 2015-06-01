using _6251App.Filter.Base;
using _6251App.Filter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _6251App.FileManipulation;

namespace _6251App
{
    public partial class App : Form
    {
        private Image origin;
        private Bitmap map;

        public App()
        {
            InitializeComponent();
            cmbEdgeDetection.Items.Add(new NullFilter());
            cmbEdgeDetection.Items.Add(new RainbowFilter());
        }

        private void btnOpenOriginal_Click(object sender, EventArgs e)
        {
            DialogFileManipulation manipuler = new DialogFileManipulation();
            Bitmap image = manipuler.Load();
            
            if (image != null)
            {
                picPreview.Image = image;
                origin = picPreview.Image;
            }
        }

        private void cmbEdgeDetection_SelectedIndexChanged(object sender, EventArgs e)
        {
            IFilter filter = (IFilter)cmbEdgeDetection.SelectedItem;
            Bitmap temp = new Bitmap(origin, new Size(picPreview.Width, picPreview.Height));
            Bitmap filtered = filter.Apply(temp);
            picPreview.Image = filtered;
        }
    }
}
