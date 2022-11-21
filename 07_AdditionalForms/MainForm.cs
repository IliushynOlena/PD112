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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Open new Form
            //SecondForm form = new SecondForm(textBox1.Text);           
            ////form.Show();//non modal mode
            //form.ShowDialog();// modal mode

            //2
            //SecondForm form = new SecondForm();
            //form.UserName = textBox1.Text;
            //form.Show();//non modal mode
            ////form.ShowDialog();// modal mode

            //3
            SecondForm form = new SecondForm();
       
            form.Show(textBox1.Text);//non modal mode
            //form.ShowDialog();// modal mode

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //1 - pull
            //LoginInfo info;
            //LoginForm loginForm = new LoginForm();
            //if (loginForm.ShowDialog() == DialogResult.OK)
            //{
            //    info = loginForm.Info;
            //    loginLb.Text = info.Login;
            //    passwordLb.Text = info.Password;
            //}
            //2 - push
            LoginInfo info = new LoginInfo();
            LoginForm loginForm = new LoginForm(info);
            if (loginForm.ShowDialog() == DialogResult.OK)
            {

                loginLb.Text = info.Login;
                passwordLb.Text = info.Password;
            }
        }
    }
}
