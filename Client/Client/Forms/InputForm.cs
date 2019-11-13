using ClassLibrary;
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
    public partial class InputForm : Form
    {
        public InputForm()
        {
            InitializeComponent();
            textBoxDateTime.Text = DateTime.Now.ToString();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var dataModel = new DataModel();
            dataModel.SecondName = textBoxSecondName.Text;
            dataModel.MiddleName = textBoxMiddleName.Text;
            dataModel.FirstName = textBoxFirstName.Text;
            dataModel.Sum = Int32.Parse(textBoxSum.Text);
            dataModel.IsPaid = checkBoxIsPaid.Checked;
            dataModel.Date = Convert.ToDateTime(textBoxDateTime.Text);

            var connection = new ConnectionHandler();
            connection.SendToServer(dataModel);
            var handler = new OutputFormHandler();
            handler.Update();
        }      
    }
}
