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
    public partial class LoginForm : Form
    {
        public LoginInfo Info { get; set; }
        public LoginForm()
        {
            InitializeComponent();
            Info = new LoginInfo();
        }
        public LoginForm(LoginInfo info)
        {
            InitializeComponent();
            Info = info;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            //1 - pull
            //Info = new LoginInfo()
            //{
            //    Login = LoginTb.Text,
            //    Password = PasswordTb.Text
            //};

            //2 - push
            if(string.IsNullOrWhiteSpace(LoginTb.Text)|| string.IsNullOrWhiteSpace(PasswordTb.Text))
            {
                MessageBox.Show("Enter login or password");
                return;
            }
           
            Info.Login = LoginTb.Text;
            Info.Password = PasswordTb.Text;
            this.DialogResult = DialogResult.OK;    
            this.Close();
        }
    }
}
