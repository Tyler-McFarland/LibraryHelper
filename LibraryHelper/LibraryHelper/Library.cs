using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryHelper
{
    public partial class frmLibrary : Form
    {
        private int currentImage = 0;
        private bookData bookData = new bookData();

        public frmLibrary()
        {
            InitializeComponent();
        }

        private void frmLibrary_Load(object sender, EventArgs e)
        {
            loadImagesIntoList();
            loadImageData();
        }

        private void loadImagesIntoList()
        {
            if (Directory.Exists(@"C:\LibraryHelperFiles\ImagesFolder"))
            {
                List<string> images = Directory.GetFiles(@"C:\LibraryHelperFiles\ImagesFolder").ToList();
                foreach (var image in images)
                {
                    imgBooks.Images.Add(Image.FromFile(image));
                }
                picBook.Image = imgBooks.Images[0];
            }
            else
            {
                Directory.CreateDirectory(@"C:\LibraryHelperFiles\ImagesFolder");
                MessageBox.Show("Any images you want to show enter in the Images folder, if you can't find it message Tyler");
            }
        }

        private void loadImageData()
        {
            if (File.Exists(@"C:\LibraryHelperFiles\ImagesFolder\fileData.txt"))
            {
                JsonSerializer jsonSerializer = new JsonSerializer();
                var json = File.ReadAllText(@"C:\LibraryHelperFiles\ImagesFolder\fileData.txt");
                bookData = jsonSerializer.Deserialize<bookData>(json);
            }
        }

        private void frmLibrary_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMain frm = new frmMain();
            frm.Visible = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (imgBooks.Images.Empty != true)
            {
                if (imgBooks.Images.Count-1 > currentImage)
                {
                    currentImage++;
                }
                else
                {
                    currentImage = 0;
                }

                picBook.Image = imgBooks.Images[currentImage];
              
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
