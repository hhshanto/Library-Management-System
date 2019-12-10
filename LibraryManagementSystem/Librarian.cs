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
    public partial class Librarian : Form
    {
        DataAccess.LibraryInfo lib = new DataAccess.LibraryInfo();
        public static int z;
        int PanelWidth;
        bool isCollapsed;
        int PanelHeight;
        bool isCollapsed1;
        int PanelWidth1;
        bool isCollapsed2;
        private string userid;
        Book bk = new Book();
        Member mem = new Member();
        public Librarian(string userID)
        {
            InitializeComponent();
            PanelWidth = menuPanel.Width;
            isCollapsed = false;
            PanelWidth1 = manageUserPanel.Width;
            isCollapsed1 = false;
            PanelHeight = changePassPanel.Height;
            isCollapsed2 = false;
            this.userid = userID;
            filterCombo.SelectedItem = "Book Name";
            searchDataGrid.AllowUserToAddRows = false;
            userGridView.AllowUserToAddRows = false;
            userGridView.ReadOnly = true;
            searchDataGrid.ReadOnly = true;
            updateBtn.Enabled = false;
            deleteBtn.Enabled = false;
            userUpgradeBtn.Enabled = false;
            userAddBtn.Enabled = false;
            DataTable dtab = lib.search(3, searchBox.Text);
            DataTable loadTable = lib.loadRequestedBook(0, userid);
            requestedBookView.DataSource = loadTable;
            requestedBookView.AllowUserToAddRows = false;
            requestedGridView.DataSource = dtab;
            requestedGridView.AllowUserToAddRows = false;
            requestedGridView.ReadOnly = true;

        }
        private void manageUser_Click(object sender, EventArgs e)
        {
            userManageTimer.Start();
        }

        

        private void Menu_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                menuPanel.Width = menuPanel.Width + 10;
                if (menuPanel.Width >= PanelWidth)
                {
                    timer1.Stop();
                    isCollapsed = false;
                    this.Refresh();
                }
            }
            else
            {
                menuPanel.Width = menuPanel.Width - 10;
                if (menuPanel.Width <= 60)
                {
                    timer1.Stop();
                    isCollapsed = true;
                    this.Refresh();
                }
            }
        }

        private void changePassword_Click(object sender, EventArgs e)
        {
            passwordTimer.Start();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void userManageTimer_Tick(object sender, EventArgs e)
        {
            if (isCollapsed1)
            {
                manageUserPanel.Width = manageUserPanel.Width - 835;
                if (manageUserPanel.Width >= PanelWidth1)
                {
                    userManageTimer.Stop();
                    isCollapsed1 = false;
                    this.Refresh();
                }
                if (isCollapsed2)
                {
                    changePassPanel.Height = changePassPanel.Height - 375;
                    if (changePassPanel.Height >= PanelHeight)
                    {
                        passwordTimer.Stop();
                        isCollapsed2 = false;
                        this.Refresh();
                    }
                }
            }
            else
            {
                manageUserPanel.Width = manageUserPanel.Width + 835;
                if (manageUserPanel.Width >= 10)
                {
                    userManageTimer.Stop();
                    isCollapsed1 = true;
                    this.Refresh();
                }
            }
        }

        private void passwordTimer_Tick(object sender, EventArgs e)
        {
            if (isCollapsed2)
            {
                changePassPanel.Height = changePassPanel.Height - 375;
                if (changePassPanel.Height >= PanelHeight)
                {
                    passwordTimer.Stop();
                    isCollapsed2 = false;
                    this.Refresh();
                }
            }
            else
            {
                changePassPanel.Height = changePassPanel.Height + 375;
                if (changePassPanel.Height >= 10)
                {
                    passwordTimer.Stop();
                    isCollapsed2 = true;
                    this.Refresh();
                }
                if (isCollapsed1)
                {
                    manageUserPanel.Width = manageUserPanel.Width - 835;
                    if (manageUserPanel.Width >= PanelWidth1)
                    {
                        userManageTimer.Stop();
                        isCollapsed1 = false;
                        this.Refresh();
                    }
                }
            }
        }

        private void bookPanelBtn_Click(object sender, EventArgs e)
        {
            BookTimer.Start();
        }

        private void BookTimer_Tick(object sender, EventArgs e)
        {
            if (isCollapsed2)
            {
                changePassPanel.Height = changePassPanel.Height - 365;
                if (changePassPanel.Height >= PanelHeight)
                {
                    passwordTimer.Stop();
                    isCollapsed2 = false;
                    this.Refresh();
                }
                
            }
            else if (isCollapsed1)
            {
                manageUserPanel.Width = manageUserPanel.Width - 825;
                if (manageUserPanel.Width >= PanelWidth1)
                {
                    userManageTimer.Stop();
                    isCollapsed1 = false;
                    this.Refresh();
                }
            }
            else
            {
                BookTimer.Stop();
            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            this.Hide();
            lg.Show();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if(bookNameBox.Text.Equals(""))
            {
                MessageBox.Show("Enter Book Name.");
            }
            else if (BookTypeBox.Equals(""))
            {
                MessageBox.Show("Enter Book Type.");
            }
            else if (authorBox.Equals(""))
            {
                MessageBox.Show("Enter Author Name.");
            }
            else if (pubYearBox.Equals(""))
            {
                MessageBox.Show("Enter Publish Year.");
            }
            else if (quantityBox.Equals(""))
            {
                MessageBox.Show("Enter Quantity.");
            }
            else
            {
                bk.BookName = bookNameBox.Text;
                bk.BookType = BookTypeBox.Text;
                bk.AuthorName = authorBox.Text;
                bk.PubYear = pubYearBox.Text;
                bk.Quantity = quantityBox.Text;
                bk.ReviewPoint = reviewBox.Text;
                bk.Status = "Available";
                if(z==1)
                {
                    int a = lib.bookAdd(1, bk);

                    if (a == 1)
                    {
                        MessageBox.Show("done");

                    }
                    if (a == 0)
                    {
                        MessageBox.Show("not done");

                    }
                }
                else if (z==2)
                {
                    int a = lib.bookAdd(2, bk);

                    if (a == 1)
                    {
                        MessageBox.Show("done");

                    }
                    if (a == 0)
                    {
                        MessageBox.Show("not done");

                    }
                }
                
            }
            
        }

        private void changePassBtn_Click(object sender, EventArgs e)
        {
         
        }

        private void changePassBtn_Click_1(object sender, EventArgs e)
        {
            if (lib.changePassword(this.userid, currentPassBox.Text, newPassBox.Text))
            {

                MessageBox.Show("Successful");
            }
            else
                MessageBox.Show("Unsuccessful");
        }

        private void searchBox_KeyUp(object sender, KeyEventArgs e)
        {
           
            if (filterCombo.Text.Equals("Book Name"))
            {

                DataTable dt = lib.search(1, searchBox.Text);
                
                searchDataGrid.DataSource = dt;
                searchDataGrid.Columns["bookid"].Visible = false;

            }
            else
            {

                searchDataGrid.DataSource = lib.search(2, searchBox.Text);

            }
            
        }

        private void searchDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = searchDataGrid.CurrentCell.RowIndex;
            //int columnindex = searchDataGrid.CurrentCell.ColumnIndex;
            bookNameBox.Text= searchDataGrid.Rows[rowindex].Cells[0].Value.ToString();
            authorBox.Text= searchDataGrid.Rows[rowindex].Cells[1].Value.ToString();
            pubYearBox.Text= searchDataGrid.Rows[rowindex].Cells[2].Value.ToString();
            quantityBox.Text= searchDataGrid.Rows[rowindex].Cells[3].Value.ToString();
            reviewBox.Text= searchDataGrid.Rows[rowindex].Cells[4].Value.ToString();
            bk.BookID= searchDataGrid.Rows[rowindex].Cells[5].Value.ToString();
            BookTypeBox.Text = searchDataGrid.Rows[rowindex].Cells[6].Value.ToString();
            updateBtn.Enabled = true;
            deleteBtn.Enabled = true;
            addBtn.Enabled = false;
            

        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            bk.BookName = bookNameBox.Text;
            bk.AuthorName = authorBox.Text;
            bk.PubYear = pubYearBox.Text;
            bk.Quantity = quantityBox.Text;
            bk.ReviewPoint = reviewBox.Text;
            bk.BookType = BookTypeBox.Text;
            int a = lib.UpdateBook(bk);
            if (a == 1)
            {
                MessageBox.Show("Update Successfull");

            }
            if (a == 0)
            {
                MessageBox.Show("Update Not Successfull");

            }

        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            int a = lib.DeleteBook(bk);
            if (a == 1)
            {
                userIdBox.Text = "";
                userNameBox.Text = "";
                userAddressBox.Text = "";
                userPhoneBox.Text = "";
                userTypeComboBox.Text = "";
                MessageBox.Show("Delete Successfull");

            }
            if (a == 0)
            {
                MessageBox.Show("Delete Not Successfull");

            }

        }

        private void userAddBtn_Click(object sender, EventArgs e)
        {
            mem.Username = userIdBox.Text;
            mem.Name = userNameBox.Text;
            mem.Phone = userPhoneBox.Text;
            mem.Address = userAddressBox.Text;
            mem.MemberType = userTypeComboBox.Text;
            if(userTypeComboBox.Text.Equals(""))
            {
                MessageBox.Show("Member type must be selected.");
            }
            else
            {
                int a = lib.UpdateMemberList(mem, userTypeComboBox.Text);
                if (a == 1)
                {
                    MessageBox.Show("Added");

                }
                if (a == 0)
                {
                    MessageBox.Show("Not Added");

                }
            }
            
        }

        private void userRemoveBtn_Click(object sender, EventArgs e)
        {
            int a =lib.UserRemove(userIdBox.Text);
            if (a == 1)
            {
                MessageBox.Show("Delete Successful");
            }
            else
                MessageBox.Show("Delete Unsuccessful");
        }


        private void searchbox1_KeyUp(object sender, KeyEventArgs e)
        {
            DataTable dt = lib.search(0, searchbox1.Text);

            userGridView.DataSource = dt;
        }

        private void userGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex2 = userGridView.CurrentCell.RowIndex;
            //int columnindex = searchDataGrid.CurrentCell.ColumnIndex;
            userIdBox.Text = userGridView.Rows[rowindex2].Cells[0].Value.ToString();
            userNameBox.Text = userGridView.Rows[rowindex2].Cells[1].Value.ToString();
            userAddressBox.Text = userGridView.Rows[rowindex2].Cells[2].Value.ToString();
            userPhoneBox.Text = userGridView.Rows[rowindex2].Cells[3].Value.ToString();
            userTypeComboBox.Text= userGridView.Rows[rowindex2].Cells[4].Value.ToString();
            userUpgradeBtn.Enabled = true;
        }

        private void userUpgradeBtn_Click(object sender, EventArgs e)
        {
            mem.Username = userIdBox.Text;
            mem.Name = userNameBox.Text;
            mem.Phone = userPhoneBox.Text;
            mem.Address = userAddressBox.Text;
            mem.MemberType = userTypeComboBox.Text;

            int a = lib.UpgradeMember(mem,userTypeComboBox.Text);
            if (a == 1)
            {
                MessageBox.Show("Upgrade Successful");
            }
            if (a == 0)
            {
                MessageBox.Show("Upgrade not Successful");

            }
        }

        private void requestedGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = requestedGridView.CurrentCell.RowIndex;
            //int columnindex = searchDataGrid.CurrentCell.ColumnIndex;
            userIdBox.Text = requestedGridView.Rows[rowindex].Cells[0].Value.ToString();
            userNameBox.Text = requestedGridView.Rows[rowindex].Cells[1].Value.ToString();
            userAddressBox.Text = requestedGridView.Rows[rowindex].Cells[2].Value.ToString();
            userPhoneBox.Text = requestedGridView.Rows[rowindex].Cells[3].Value.ToString();
            userAddBtn.Enabled = true;
            z = 2;
        }
        public void refresh()
        {

        }

        private void adminInfoBtn_Click(object sender, EventArgs e)
        {
            LibrarianEntity libb = new LibrarianEntity();
            MessageBox.Show("Name: " +libb.LibrarianName+"\nUsername: "+libb.LibrarianUserName+"\nEmail: "+libb.LibrarianEmail+"\nPhone: "+libb.LibrarianPhone+"\nAddress: "+libb.LibrarianAddress+"\nJoin Date: "+libb.LibrarianJoinDate);
        }

        private void requestedBookView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = requestedBookView.CurrentCell.RowIndex;
            //int columnindex = searchDataGrid.CurrentCell.ColumnIndex;
            bookNameBox.Text = requestedBookView.Rows[rowindex].Cells[0].Value.ToString();
            authorBox.Text = requestedBookView.Rows[rowindex].Cells[1].Value.ToString();
            pubYearBox.Text = requestedBookView.Rows[rowindex].Cells[2].Value.ToString();
            BookTypeBox.Text = "";
            quantityBox.Text = "5";
            z = 2;
        }

        private void clearBtnL_Click(object sender, EventArgs e)
        {
            bookNameBox.Text = "";
            BookTypeBox.Text = "";
            authorBox.Text = "";
            pubYearBox.Text = "";
            quantityBox.Text = "";
            reviewBox.Text = "";
            addBtn.Enabled = true;
        }
    }
}
