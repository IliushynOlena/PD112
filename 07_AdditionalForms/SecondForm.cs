using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _07_AdditionalForms
{
    public partial class SecondForm : Form
    {
        //public string UserName { get; set; }//texbox.Text1
        private string userName;

        public string UserName
        {
            get { return userName; }
            set 
            {
                userName = value;
                UserLb.Text = $"Hello, {UserName}";
            }
        }

        public SecondForm()
        {
            InitializeComponent();
        }
        public SecondForm(string name)
        {
            InitializeComponent();
            UserName = name;
            UserLb.Text = $"Hello, {UserName}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"User name {UserName}");
        }
        public new void  Show(string name)
        {
            UserName = name;
            this.Show();
        }
    }
}
