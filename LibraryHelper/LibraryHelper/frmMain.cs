using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LibraryHelper
{
    public partial class frmMain : Form
    {
        public static char userType = 'n';

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            List<string> usernames = getUsernames();

            bool valid = Validate(usernames, txtUser.Text.ToLower());

            if (valid == false)
            {
                MessageBox.Show("User doesn't exist, please try again");
            }
            else
            {
                frmLibrary library = new frmLibrary();
                this.Visible = false;
                library.ShowDialog();
                library.Activate();
            }
        }

        private List<string> getUsernames() 
        {
            if (!(File.Exists(@"C:\LibraryHelperFiles\MyClassroom.txt")))
            {
                Directory.CreateDirectory(@"C:\LibraryHelperFiles");
                File.Create(@"C:\LibraryHelperFiles\MyClassroom.txt");
            }

            return File.ReadAllLines(@"C:\LibraryHelperFiles\MyClassroom.txt").ToList();
        }

        private bool Validate(List<string> usernames, string enteredUser)
        {
            if (usernames.Contains(enteredUser))
            {
                userType = 's';
                return true;
            }
            else
            {
                if (enteredUser.StartsWith("*") && (enteredUser.Substring(1) == "kristen"))
                {
                    userType = 't';
                    return true;
                }
                return false;
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
