using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            textBoxLogin.Text = "login";
            textBoxPassword.Text = "Password";

            if (textBoxLogin.Text == "login" && textBoxPassword.Text == "Password")
            {
                InputForm inputForm = new InputForm();
                inputForm.Show();

                OutputForm outputForm = new OutputForm();
                outputForm.Show();
            }
            else
            {
                MessageBox.Show("Invalid Login Or/And Password!", "Error", MessageBoxButtons.OK);
            }
        }
    }
}
