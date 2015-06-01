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
            OpenFileDialog op = new OpenFileDialog();
            DialogResult dr = op.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string path = op.FileName;
                picPreview.Load(path);
                Bitmap temp = new Bitmap(picPreview.Image, new Size(picPreview.Width, picPreview.Height));
                picPreview.Image = temp;
                map = new Bitmap(picPreview.Image);
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
