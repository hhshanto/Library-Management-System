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
    public partial class Faculty : Form
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
        Book bk = new Book();
        public Faculty(string userID)
        {
            InitializeComponent();
            PanelWidth = menuPanelF.Width;
            isCollapsed = false;
            PanelWidth1 = infoPanelF.Width;
            isCollapsed1 = false;
            PanelHeight = facultyPassPanel.Height;
            isCollapsed2 = false;
            this.userid = userID;
            filterCombo.SelectedItem = "Book Name";
            searchDataGrid.AllowUserToAddRows = false;

            DataTable dtab = lib.search(4, this.userid);
            borrowedBookViewF.DataSource = dtab;
            borrowedBookViewF.Columns["bookid"].Visible = false;
            DataTable loadTable = lib.loadInfo(0, userid);
            nameBoxF.Text = loadTable.Rows[0].Field<string>(0);
            addressBoxF.Text = loadTable.Rows[0].Field<string>(1);
            phoneBoxF.Text = loadTable.Rows[0].Field<string>(2);

            borrowedBookViewF.AllowUserToAddRows = false;
            borrowedBookViewF.ReadOnly = true;
            //returnDateBoxF.Text=DateTime.Now.Date.ToShortDateString();
        }

        private void exitFBtn_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void facultyLogoutBtn_Click(object sender, EventArgs e)
        {
            Login lg1 = new Login();
            this.Hide();
            lg1.Show();
        }

        private void fcaultyChangePassBtn_Click(object sender, EventArgs e)
        {
            FpassTime.Start();
        }

        private void BooksBtn_Click(object sender, EventArgs e)
        {
            FbookTimer.Start();
        }

        private void FinfoBtn_Click(object sender, EventArgs e)
        {
            FinfoBoxTimer.Start();
            DataTable dtab = lib.search(4, this.userid);

            borrowedBookViewF.DataSource = dtab;
            borrowedBookViewF.Columns["bookid"].Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                menuPanelF.Width = menuPanelF.Width + 10;
                if (menuPanelF.Width >= PanelWidth)
                {
                    timer1.Stop();
                    isCollapsed = false;
                    this.Refresh();
                }
            }
            else
            {
                menuPanelF.Width = menuPanelF.Width - 10;
                if (menuPanelF.Width <= 60)
                {
                    timer1.Stop();
                    isCollapsed = true;
                    this.Refresh();
                }
            }
        }

        private void menuBtn_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void FpassTime_Tick(object sender, EventArgs e)
        {
            if (isCollapsed2)
            {
                facultyPassPanel.Height = facultyPassPanel.Height - 400;
                if (facultyPassPanel.Height >= PanelHeight)
                {
                    FpassTime.Stop();
                    isCollapsed2 = false;
                    this.Refresh();
                }
            }
            else
            {
                facultyPassPanel.Height = facultyPassPanel.Height + 400;
                if (facultyPassPanel.Height >= 10)
                {
                    FpassTime.Stop();
                    isCollapsed2 = true;
                    this.Refresh();
                }
                if (isCollapsed1)
                {
                    infoPanelF.Width = infoPanelF.Width - 825;
                    if (infoPanelF.Width >= PanelWidth1)
                    {
                        FinfoBoxTimer.Stop();
                        isCollapsed1 = false;
                        this.Refresh();
                    }
                }
            }
        }

        private void FinfoBoxTimer_Tick(object sender, EventArgs e)
        {
            if (isCollapsed1)
            {
                infoPanelF.Width = infoPanelF.Width - 825;
                if (infoPanelF.Width >= PanelWidth1)
                {
                    FinfoBoxTimer.Stop();
                    isCollapsed1 = false;
                    this.Refresh();
                }
                if (isCollapsed2)
                {
                    facultyPassPanel.Height = facultyPassPanel.Height - 400;
                    if (facultyPassPanel.Height >= PanelHeight)
                    {
                        FpassTime.Stop();
                        isCollapsed2 = false;
                        this.Refresh();
                    }
                }
            }
            else
            {
                infoPanelF.Width = infoPanelF.Width + 825;
                if (infoPanelF.Width >= 10)
                {
                    FinfoBoxTimer.Stop();
                    isCollapsed1 = true;
                    this.Refresh();
                }
                if (isCollapsed2)
                {
                    facultyPassPanel.Height = facultyPassPanel.Height - 400;
                    if (facultyPassPanel.Height >= PanelHeight)
                    {
                        FpassTime.Stop();
                        isCollapsed2 = false;
                        this.Refresh();
                    }
                }
            }
        }

        private void FbookTimer_Tick(object sender, EventArgs e)
        {
            if (isCollapsed2)
            {
                facultyPassPanel.Height = facultyPassPanel.Height - 400;
                if (facultyPassPanel.Height >= PanelHeight)
                {
                    FpassTime.Stop();
                    isCollapsed2 = false;
                    this.Refresh();
                }

            }
            else if (isCollapsed1)
            {
                infoPanelF.Width = infoPanelF.Width - 825;
                if (infoPanelF.Width >= PanelWidth1)
                {
                    FinfoBoxTimer.Stop();
                    isCollapsed1 = false;
                    this.Refresh();
                }
            }
            else
            {
                FbookTimer.Stop();
            }
        }

        private void borrowFBtn_Click(object sender, EventArgs e)
        {
            borrow.userId = this.userid;
            var a = DateTime.Now;
            borrow.borrowDate=a.Date.ToShortDateString();
            var b = a.AddDays(7).ToShortDateString();
            borrow.returnDate = b;
            int x =lib.BorrowBookAdd(borrow);
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
            if (lib.changePassword(this.userid, currentPassBoxF.Text, newPassBoxF.Text))
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
            requestBtn.Enabled = false;
        }

        private void borrowedBookViewF_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void borrowedBookViewF_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex2 = borrowedBookViewF.CurrentCell.RowIndex;
            //int columnindex = searchDataGrid.CurrentCell.ColumnIndex;
            bookNameBoxF.Text = borrowedBookViewF.Rows[rowindex2].Cells[0].Value.ToString();
            borrow.bookId = Convert.ToInt32(borrowedBookViewF.Rows[rowindex2].Cells[4].Value.ToString());
            borrow.userId = this.userid;
        }

        private void returnBtnF_Click(object sender, EventArgs e)
        {
            int x = lib.returnBook(borrow, reviewBoxF.Text);
            if (x == 1)
            {
                MessageBox.Show("Returned Successfully");

            }
            if (x == 0)
            {
                MessageBox.Show("Failed to return..");

            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            bookNameBox.Text = "";
            authorBox.Text = "";
            pubYearBox.Text = "";
            quantityBox.Text = "";
            reviewBox.Text = "";
            requestBtn.Enabled = true;
        }

        private void requestBtn_Click(object sender, EventArgs e)
        {
            bk.BookName = bookNameBox.Text;
            bk.AuthorName = authorBox.Text;
            bk.PubYear = pubYearBox.Text;
            //bk.Quantity = quantityBox.Text;
            bk.ReviewPoint = reviewBox.Text;
            //bk.Status = "Available";
            int a = lib.RequestbookAdd(bk);
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
