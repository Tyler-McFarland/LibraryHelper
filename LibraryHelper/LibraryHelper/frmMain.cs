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
        }

        private List<string> getUsernames() 
        {
            if (!(File.Exists(@"C:\LibraryHelperFile\MyClassroom")))
            {
                Directory.CreateDirectory(@"C:\LibraryHelperFile");
                File.Create(@"C:\LibraryHelperFile\MyClassroom");
            }

            return File.ReadAllLines(@"C:\LibraryHelperFile\MyClassroom").ToList();
        }

        private bool Validate(List<string> usernames, string enteredUser)
        {
            if (usernames.Contains(enteredUser))
            {
                return true;
            }
            else
            {
                if (enteredUser.StartsWith("*") && (enteredUser.Substring(1) == "kristen"))
                {
                    //this is the teacher
                    return true;
                }
                return false;
            }
        }
    }
}
