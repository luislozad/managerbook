using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagerBookFinal.Interface;

namespace ManagerBookFinal.Component.View
{
    public partial class ImageCover : UserControl
    {

        private string ImageLocation = null;
        public ImageCover()
        {
            InitializeComponent();
        }

        public void SetImage(string imageLocation)
        {
            ImageLocation = imageLocation;
            if (NewImage(imageLocation, out Image image))
            {
                Image.BackgroundImage = image;
            }
        }

        public string GetImageLocation()
        {
            return ImageLocation;
        }

        private bool NewImage(string path, out Image image)
        {
            if (path != null)
            {
                image = new Bitmap(path);
                return true;
            }
            image = null;
            return false;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if(ImageOpenDialog.ShowDialog() == DialogResult.OK)
            {
                SetImage(ImageOpenDialog.FileName);
            }
        }
    }
}
