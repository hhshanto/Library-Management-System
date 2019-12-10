using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using DataAccess;
using Framework;

namespace LibraryManagementSystem
{
    public partial class Student : Form
    {
        DataAccess.LibraryInfo lib = new DataAccess.LibraryInfo();
        int PanelWidth;
        bool isCollapsed;
        int PanelHeight;
        bool isCollapsed1;
        int PanelWidth1;
        bool isCollapsed2;
        private string userid;
        BorrowInfo borrow = new BorrowInfo();
        public Student(string userID)
        {
            InitializeComponent();
            PanelWidth = menuPanelS.Width;
            isCollapsed = false;
            PanelWidth1 = infoPanelS.Width;
            isCollapsed1 = false;
            PanelHeight = studentPassPanel.Height;
            isCollapsed2 = false;
            this.userid = userID;
            filterCombo.SelectedItem = "Book Name";
            searchDataGrid.AllowUserToAddRows = false;

            DataTable dtab = lib.search(4, this.userid);
            borrowedBookViewS.DataSource = dtab;
            borrowedBookViewS.AllowUserToAddRows = false;
            borrowedBookViewS.ReadOnly = true;
            //returnDateBoxS.Text = DateTime.Now.Date.ToShortDateString();
            DataTable loadTable = lib.loadInfo(0, userid);
            nameBoxS.Text = loadTable.Rows[0].Field<string>(0);
            addressBoxS.Text = loadTable.Rows[0].Field<string>(1);
            phoneBoxS.Text = loadTable.Rows[0].Field<string>(2);
        }
        private void exitFBtnS_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void studentLogoutBtn_Click(object sender, EventArgs e)
        {
            Login lg2 = new Login();
            this.Hide();
            lg2.Show();
        }

        private void menuBtnS_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                menuPanelS.Width = menuPanelS.Width + 10;
                if (menuPanelS.Width >= PanelWidth)
                {
                    timer1.Stop();
                    isCollapsed = false;
                    this.Refresh();
                }
            }
            else
            {
                menuPanelS.Width = menuPanelS.Width - 10;
                if (menuPanelS.Width <= 60)
                {
                    timer1.Stop();
                    isCollapsed = true;
                    this.Refresh();
                }
            }
        }

        private void studentChangePassBtn_Click(object sender, EventArgs e)
        {
            SpassTimer.Start();
        }

        private void BooksBtnS_Click(object sender, EventArgs e)
        {
            SbookTimer.Start();
        }

        private void FinfoTimer_Tick(object sender, EventArgs e)
        {
            if (isCollapsed1)
            {
                infoPanelS.Width = infoPanelS.Width - 825;
                if (infoPanelS.Width >= PanelWidth1)
                {
                    SinfoTimer.Stop();
                    isCollapsed1 = false;
                    this.Refresh();
                }
                if (isCollapsed2)
                {
                    studentPassPanel.Height = studentPassPanel.Height - 400;
                    if (studentPassPanel.Height >= PanelHeight)
                    {
                        SpassTimer.Stop();
                        isCollapsed2 = false;
                        this.Refresh();
                    }
                }
            }
            else
            {
                infoPanelS.Width = infoPanelS.Width + 825;
                if (infoPanelS.Width >= 10)
                {
                    SinfoTimer.Stop();
                    isCollapsed1 = true;
                    this.Refresh();
                }
                if (isCollapsed2)
                {
                    studentPassPanel.Height = studentPassPanel.Height - 400;
                    if (studentPassPanel.Height >= PanelHeight)
                    {
                        SpassTimer.Stop();
                        isCollapsed2 = false;
                        this.Refresh();
                    }
                }
            }
        }

        private void SinfoBtn_Click(object sender, EventArgs e)
        {
            SinfoTimer.Start();
            DataTable dtab = lib.search(4, this.userid);
            borrowedBookViewS.DataSource = dtab;
        }

        private void SpassTimer_Tick(object sender, EventArgs e)
        {
            if (isCollapsed2)
            {
                studentPassPanel.Height = studentPassPanel.Height - 400;
                if (studentPassPanel.Height >= PanelHeight)
                {
                    SpassTimer.Stop();
                    isCollapsed2 = false;
                    this.Refresh();
                }
            }
            else
            {
                studentPassPanel.Height = studentPassPanel.Height + 400;
                if (studentPassPanel.Height >= 10)
                {
                    SpassTimer.Stop();
                    isCollapsed2 = true;
                    this.Refresh();
                }
                if (isCollapsed1)
                {
                    infoPanelS.Width = infoPanelS.Width - 825;
                    if (infoPanelS.Width >= PanelWidth1)
                    {
                        SinfoTimer.Stop();
                        isCollapsed1 = false;
                        this.Refresh();
                    }
                }
            }
        }

        private void SbookTimer_Tick(object sender, EventArgs e)
        {
            if (isCollapsed2)
            {
                studentPassPanel.Height = studentPassPanel.Height - 400;
                if (studentPassPanel.Height >= PanelHeight)
                {
                    SpassTimer.Stop();
                    isCollapsed2 = false;
                    this.Refresh();
                }

            }
            else if (isCollapsed1)
            {
                infoPanelS.Width = infoPanelS.Width - 825;
                if (infoPanelS.Width >= PanelWidth1)
                {
                    SinfoTimer.Stop();
                    isCollapsed1 = false;
                    this.Refresh();
                }
            }
            else
            {
                SbookTimer.Stop();
            }
        }

        private void borrowFBtn_Click(object sender, EventArgs e)
        {
            borrow.userId = this.userid;
            var a = DateTime.Now;
            borrow.borrowDate = a.Date.ToShortDateString();
            var b = a.AddDays(7).ToShortDateString();
            borrow.returnDate = b;
            int x = lib.BorrowBookAdd(borrow);
            if (x == 1)
            {
                MessageBox.Show("Added to Borrow List");

            }
            if (x == 0)
            {
                MessageBox.Show("The book is not available");

            }
        }

        private void ChangePassBtnF_Click(object sender, EventArgs e)
        {
            if (lib.changePassword(this.userid, currentPassBoxS.Text, newPassBoxS.Text))
            {

                MessageBox.Show("Password chagnged successfully.");
            }
            else
                MessageBox.Show("Password chagnged unsuccessful.");
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void searchDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex2 = searchDataGrid.CurrentCell.RowIndex;
            //int columnindex = searchDataGrid.CurrentCell.ColumnIndex;
            bookNameBox.Text = searchDataGrid.Rows[rowindex2].Cells[0].Value.ToString();
            borrow.bookName = bookNameBox.Text;
            authorBox.Text = searchDataGrid.Rows[rowindex2].Cells[1].Value.ToString();
            borrow.authorName = authorBox.Text;
            pubYearBox.Text = searchDataGrid.Rows[rowindex2].Cells[2].Value.ToString();
            quantityBox.Text = searchDataGrid.Rows[rowindex2].Cells[3].Value.ToString();
            reviewBox.Text = searchDataGrid.Rows[rowindex2].Cells[4].Value.ToString();
            borrow.bookId = Convert.ToInt32(searchDataGrid.Rows[rowindex2].Cells[5].Value.ToString());
        }

        private void borrowedBookViewS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex2 = borrowedBookViewS.CurrentCell.RowIndex;
            //int columnindex = searchDataGrid.CurrentCell.ColumnIndex;
            returnDateBoxS.Text = borrowedBookViewS.Rows[rowindex2].Cells[3].Value.ToString();
            bookNameBoxS.Text = borrowedBookViewS.Rows[rowindex2].Cells[0].Value.ToString();
            borrow.bookId = Convert.ToInt32(borrowedBookViewS.Rows[rowindex2].Cells[4].Value.ToString());
            borrow.userId = this.userid;
        }

        private void returnBtnF_Click(object sender, EventArgs e)
        {
            int x = lib.returnBook(borrow, reviewBoxS.Text);
            if (x == 1)
            {
                MessageBox.Show("Returned Successfully");

            }
            if (x == 0)
            {
                MessageBox.Show("Failed to return..");

            }
        }
    }
}
