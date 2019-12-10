using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Entities;
using DataAccess;
using Framework;

namespace LibraryManagementSystem
{
    public partial class Login : Form
    {
        

        int PanelHieght;
        bool isCollapsed;
        public Login()
        {
            InitializeComponent();
            PanelHieght = panelDown.Height;
            isCollapsed = false;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                panelDown.Height = panelDown.Height - 10;
                if (panelDown.Height <= PanelHieght)
                {
                    timer1.Stop();
                    isCollapsed = false;
                    this.Refresh();
                }
            }
            else
            {
                panelDown.Height = panelDown.Height + 10;
                if (panelDown.Height >= 310)
                {
                    timer1.Stop();
                    isCollapsed = true;
                    this.Refresh();
                }
            }
        }


        private void signUpButton_Click(object sender, EventArgs e)
        {
            timer1.Start();

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Entities.EntityLogin nlog = new Entities.EntityLogin();
            nlog.Username = userNameBox.Text;
            nlog.Password = passwordBox.Text;
            nlog.KeyId = "st";
            nlog.Status = "";
            DataAccess.LibraryInfo lib = new DataAccess.LibraryInfo(nlog.Username);
            int a=lib.login(nlog);
            if (a == 1)
            {
                //MessageBox.Show("Student");
                this.Hide();
                Student st = new Student(this.userNameBox.Text);
                st.Show();
            }
            if (a == 2)
            {
                //MessageBox.Show("faculty");
                this.Hide();
                Faculty fc = new Faculty(this.userNameBox.Text);
                fc.Show();
            }
            if (a == 3)
            {
                //MessageBox.Show("Librarian");
                this.Hide();
                Librarian lib1 = new Librarian(this.userNameBox.Text);
                lib1.Show();
            }
            if (a == 4)
            {
                MessageBox.Show("Inactive");
            }
            else if(a == 0)
            {
                MessageBox.Show("Username or Password Incorrect.");
            }
        }

        
        private void createAccountButton_Click_1(object sender, EventArgs e)
        {
            DataAccess.LibraryInfo lib = new DataAccess.LibraryInfo();
            Entities.Member nmem = new Entities.Member();
            nmem.Username = userBox2.Text;
            nmem.Password = passwordBox2.Text;
            nmem.Name = nameBox2.Text;
            nmem.Address = addressBox2.Text;
            nmem.Phone = mobileBox2.Text;
            int a = lib.SignUp(nmem);
            if (a == 1)
            {
                MessageBox.Show("Sign Up Successful");

            }
            else if (a == 0)
            {
                MessageBox.Show("Sign Up Unsuccessful");

            }
            else if (a == 6)
            {
                MessageBox.Show("Invalid UserID");

            }
            else if (a == 2)
            {
                MessageBox.Show("Invalid Name");

            }
            else if (a == 3)
            {
                MessageBox.Show("Invalid Password");

            }
            else if (a == 4)
            {
                MessageBox.Show("Invalid Address");

            }
            else if (a == 5)
            {
                MessageBox.Show("Invalid Phone");

            }
            else if (a == 404)
            {
                MessageBox.Show("UserID already taken.\nChoose Different userID.");

            }
        }

        private void userNameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void passwordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }
    }
}
