using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entities;
using DataAccess;
using Framework;

namespace DataAccess
{
    public class LibraryInfo
    {
        private string userid;
        public LibraryInfo(string user)
        {
            this.userid = user;

        }
        public LibraryInfo()
        { }
        public int login(Entities.EntityLogin obj)
        {
            sqlDataAccess da = new sqlDataAccess();
            SqlCommand cmd = da.GetCommand("select keyid,status from login where userid = '" + obj.Username + "'and password like '" + obj.Password + "'");
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter DAdap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DAdap.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].Equals("st"))
                {
                    if (dt.Rows[0][1].Equals("active"))
                    {
                        cmd.Connection.Close();
                        return 1;//student and active
                    }
                    else
                    {
                        cmd.Connection.Close();
                        return 4; //inactive
                    }


                }
                else if (dt.Rows[0][0].Equals("fc"))
                {
                    if (dt.Rows[0][1].Equals("active"))
                    {
                        cmd.Connection.Close();
                        return 2;//faculty and active
                    }
                    else
                    {
                        cmd.Connection.Close();
                        return 4; //inactive
                    }

                }
                else if (dt.Rows[0][0].Equals("lb"))
                {
                    cmd.Connection.Close();
                    return 3;
                }
                else
                    return 4;

            }
            else
            {
                cmd.Connection.Close();
                return 0;
            }

        }
        public int SignUp(Member obj)
        {
            sqlDataAccess da = new sqlDataAccess();
            if (obj.Username.Equals(""))
            {
                return 6;
            }
            else if (obj.Name.Equals(""))
            {
                return 2;
            }
            else if (obj.Password.Equals(""))
            {
                return 3;
            }
            else if (obj.Address.Equals(""))
            {
                return 4;
            }
            else if (obj.Phone.Equals(""))
            {
                return 5;
            }
            else
            {
                SqlCommand cmd1 = da.GetCommand("select * from login where userid = '" + obj.Username + "'");
                cmd1.Connection.Open();
                cmd1.ExecuteNonQuery();
                SqlDataAdapter DAdap = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                DAdap.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    cmd1.Connection.Close();
                    return 404;
                }
                else
                {
                    SqlCommand cmd = da.GetCommand("insert into MemberTable (userid,name,address,phone,memberType) values ('" + obj.Username + "','" + obj.Name + "','" + obj.Address + "','" + obj.Phone + "','" + "inactive" + "')");
                    SqlCommand cmd2 = da.GetCommand("insert into Login (userid,password,keyid,status) values ('" + obj.Username + "','" + obj.Password + "','" + "" + "','" + "Inactive" + "')");
                    cmd.Connection.Open();
                    int i = cmd.ExecuteNonQuery();



                    if (i > 0)
                    {
                        cmd.Connection.Close();
                        cmd2.Connection.Open();
                        cmd2.ExecuteNonQuery();
                        cmd2.Connection.Close();
                        return 1;


                    }
                    else
                    {
                        cmd.Connection.Close();
                        return 0;
                    }
                }
            }




        }
        public int bookAdd(int j,Book obj)
        {

            sqlDataAccess da = new sqlDataAccess();
            if (j == 1)
            {
                int qn = Convert.ToInt32(obj.Quantity);
                SqlCommand cmd = da.GetCommand("insert into bookTable (BookName,AuthorName,PubYear,Quantity,Status,review,bookType) values ('" + obj.BookName + "','" + obj.AuthorName + "','" + obj.PubYear + "','" + qn + "','" + obj.Status + "','" + 0 + "','" + obj.BookType + "')");
                cmd.Connection.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    cmd.Connection.Close();
                    return 1;

                }
                else
                {
                    cmd.Connection.Close();
                    return 0;
                }
            }
            else if (j == 2)
            {
                int qn = Convert.ToInt32(obj.Quantity);
                SqlCommand cmd1 = da.GetCommand("UPDATE booktable SET bookname='" + obj.BookName + "', quantity='" + obj.Quantity + "', authorname='" + obj.AuthorName + "', pubyear='" + obj.PubYear + "', bookType='" + obj.BookType + "', status='" + obj.Status + "'where bookname = '" + obj.BookName + "'");
                cmd1.Connection.Open();
                int i = cmd1.ExecuteNonQuery();
                if (i > 0)
                {
                    cmd1.Connection.Close();
                    return 1;

                }
                else
                {
                    cmd1.Connection.Close();
                    return 0;
                }
            }
            else return 0;
            
            
        }

        public int RequestbookAdd(Book obj)
        {

            sqlDataAccess da = new sqlDataAccess();
            SqlCommand cmd = da.GetCommand("insert into bookTable (BookName,AuthorName,PubYear,Quantity,Status,review,booktype) values ('" + obj.BookName + "','" + obj.AuthorName + "','" + obj.PubYear + "','" + 0 + "','" + "Inactive" + "','" + 0 + "','" + "0" + "')");
            cmd.Connection.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                cmd.Connection.Close();
                return 1;

            }
            else
            {
                cmd.Connection.Close();
                return 0;
            }
        }
        public bool changePassword(string userid, string password, string newpass)
        {

            sqlDataAccess da = new sqlDataAccess();
            SqlCommand cmd = da.GetCommand("select password from login where userid = '" + userid + "'");
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter DAdap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DAdap.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                if (dt.Rows[0][0].Equals(password))
                {
                    cmd.Connection.Close();
                    SqlCommand cmd2 = da.GetCommand("UPDATE login SET password='" + newpass + "' where userid = '" + userid + "'");
                    cmd2.Connection.Open();
                    cmd2.ExecuteNonQuery();
                    cmd2.Connection.Close();
                    return true;
                }

                else
                {
                    cmd.Connection.Close();
                    return false;
                }
            }
            else
            {
                return false;
            }
            

        }
        public DataTable search(int i,string text)
        {
            sqlDataAccess da = new sqlDataAccess();
            if (i == 1)
            {
                SqlCommand cmd = da.GetCommand("SELECT bookname, authorname,pubyear,quantity,review,bookid,bookType FROM booktable WHERE bookName like '%" + text + "%' AND status = '" + "available" + "'");

                using (SqlDataAdapter dt = new SqlDataAdapter(cmd))
                {
                    cmd.Connection.Open();
                    DataTable tbl = new DataTable();
                    dt.Fill(tbl);
                    cmd.Connection.Close();
                    return tbl;
                }
            }
            else if (i == 2)
            {
                SqlCommand cmd = da.GetCommand("SELECT bookname, authorname,pubyear,quantity,review,bookid,bookType FROM booktable WHERE authorname like '%" + text + "%' AND status = '" + "available" + "'");

                using (SqlDataAdapter dt = new SqlDataAdapter(cmd))
                {
                    cmd.Connection.Open();
                    DataTable tbl = new DataTable();
                    dt.Fill(tbl);
                    cmd.Connection.Close();
                    return tbl;
                }
            }
            else if (i == 0)
            {
                SqlCommand cmd = da.GetCommand("SELECT userid, name,address,phone,membertype FROM memberTable WHERE (userid like '%" + text + "%' and not membertype = '" + "inactive" + "')");

                using (SqlDataAdapter dt = new SqlDataAdapter(cmd))
                {
                    cmd.Connection.Open();
                    DataTable tbl = new DataTable();
                    dt.Fill(tbl);
                    cmd.Connection.Close();
                    return tbl;
                }
            }
            else if (i == 3)
            {
                SqlCommand cmd = da.GetCommand("SELECT userid, name,address,phone FROM memberTable WHERE memberType = '" + "inactive" + "'");

                using (SqlDataAdapter dt = new SqlDataAdapter(cmd))
                {
                    cmd.Connection.Open();
                    DataTable tbl = new DataTable();
                    dt.Fill(tbl);
                    cmd.Connection.Close();
                    return tbl;
                }
            }
            else if (i == 4)
            {
                SqlCommand cmd = da.GetCommand("SELECT bookName,authorName,borrowDate,returnDate,bookId FROM borrowTable WHERE userid = '" + text + "'");

                using (SqlDataAdapter dt = new SqlDataAdapter(cmd))
                {
                    cmd.Connection.Open();
                    DataTable tbl = new DataTable();
                    dt.Fill(tbl);
                    cmd.Connection.Close();
                    return tbl;
                }
            }

            else
                return new DataTable();

            


        }
        public int UpdateBook(Book obj)
        {
            sqlDataAccess da = new sqlDataAccess();
            SqlCommand cmd = da.GetCommand("UPDATE booktable SET bookname='" + obj.BookName + "', quantity='" + obj.Quantity + "', authorname='" + obj.AuthorName + "', pubyear='" + obj.PubYear + "', booktype='" + obj.BookType + "'where bookid = '" + obj.BookID + "'");
            cmd.Connection.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                cmd.Connection.Close();
                return 1;

            }
            else
            {
                cmd.Connection.Close();
                return 0;
            }

        }
        public int UpdateMemberList(Member obj, string text)
        {
            sqlDataAccess da = new sqlDataAccess();
            SqlCommand cmd = da.GetCommand("UPDATE memberTable SET memberType='" + text + "'where userid = '" + obj.Username + "'");
            SqlCommand cmd1 = da.GetCommand("UPDATE login SET status='" + "active" + "',keyid='" + "st" + "' where userid = '" + obj.Username + "'");
            cmd.Connection.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                cmd.Connection.Close();
                cmd1.Connection.Open();
                cmd1.ExecuteNonQuery();
                cmd1.Connection.Close();
                return 1;

            }
            else
            {
                cmd.Connection.Close();
                return 0;
            }

        }
        public int DeleteBook(Book obj)
        {
            sqlDataAccess da = new sqlDataAccess();
            SqlCommand cmd = da.GetCommand("Delete booktable where bookid = '" + obj.BookID + "'");
            cmd.Connection.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                cmd.Connection.Close();
                return 1;

            }
            else
            {
                cmd.Connection.Close();
                return 0;
            }

        }
        public int DeleteUser(Member obj)
        {
            sqlDataAccess da = new sqlDataAccess();
            SqlCommand cmd = da.GetCommand("Delete login where userid = '" + obj.Username + "'");
            SqlCommand cmd1 = da.GetCommand("Delete memberTable where userid = '" + obj.Username + "'");
            cmd.Connection.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                cmd.Connection.Close();
                cmd1.Connection.Open();
                cmd1.ExecuteNonQuery();
                cmd1.Connection.Close();
                return 1;

            }
            else
            {
                cmd.Connection.Close();
                return 0;
            }

        }
        public int UpgradeMember(Member obj, string memtype)
        {
            sqlDataAccess da = new sqlDataAccess();
            int i;
            SqlCommand cmd = da.GetCommand("UPDATE memberTable SET memberType='" + memtype + "'where userid = '" + obj.Username + "'");
            if (memtype.Equals("Faculty"))
            {
                SqlCommand cmd1 = da.GetCommand("UPDATE login SET keyid ='" + "fc" + "'where userid = '" + obj.Username + "'");
                cmd.Connection.Open();
                 i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    cmd.Connection.Close();
                    cmd1.Connection.Open();
                    cmd1.ExecuteNonQuery();
                    cmd1.Connection.Close();
                    return 1;
                }
                else
                    return 0;
            }
            else if (memtype.Equals("Student"))
            {

                SqlCommand cmd1 = da.GetCommand("UPDATE login SET keyid ='" + "st" + "'where userid = '" + obj.Username + "'");
                cmd.Connection.Open();
                i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    cmd.Connection.Close();
                    cmd1.Connection.Open();
                    cmd1.ExecuteNonQuery();
                    cmd1.Connection.Close();
                    return 1;

                }
                else
                    return 0;
            }
            else
            {
                cmd.Connection.Close();
                return 0;
            }

        }
        public int UserRemove(string userid)
        {
            sqlDataAccess da = new sqlDataAccess();
            SqlCommand cmd = da.GetCommand("Delete membertable where userid = '" + userid + "'");
            SqlCommand cmd1 = da.GetCommand("Delete login where userid = '" + userid + "'");
            cmd.Connection.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {

                cmd.Connection.Close();
                cmd1.Connection.Open();
                cmd1.ExecuteNonQuery();
                cmd1.Connection.Close();
                return 1;

            }
            else
            {
                cmd.Connection.Close();
                return 0;
            }
        }
        public int BorrowBookAdd(BorrowInfo borrow)
        {
            sqlDataAccess da = new sqlDataAccess();
            int val;
            SqlCommand cmd = da.GetCommand("insert into BorrowTable (bookname,authorName,bookid,userid,borrowdate,returndate) values ('" + borrow.bookName + "','" + borrow.authorName + "','" + borrow.bookId + "','" + borrow.userId + "','" + borrow.borrowDate + "','" + borrow.returnDate + "')");
            SqlCommand cmd1 = da.GetCommand("Select quantity from booktable where bookid ='" + borrow.bookId + "'");
           
            cmd1.Connection.Open();
            cmd1.ExecuteNonQuery();
            using (SqlDataAdapter dt = new SqlDataAdapter(cmd1))
            {
                DataTable tbl = new DataTable();
                dt.Fill(tbl);
                val = (int)tbl.Rows[0][0];
                cmd1.Connection.Close();
            }
            if (val > 0)
            {
                
                
                        val = val - 1;
                        
                        SqlCommand cmd2 = da.GetCommand("UPDATE booktable SET  quantity='" + val + "'where bookid = '" + borrow.bookId + "'");
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                        ///////////////////////////////////
                        cmd2.Connection.Open();
                        cmd2.ExecuteNonQuery();
                        cmd2.Connection.Close();
                        return 1;
                

            }
            else
            {
                cmd.Connection.Close();
                return 0;
            }
            
        }
        public DataTable loadInfo(int i, string userid)
        {
            sqlDataAccess da = new sqlDataAccess();
            if (i == 0)
            {
                SqlCommand cmd = da.GetCommand("SELECT name,address,phone FROM memberTable WHERE userid = '" + userid + "'");

                using (SqlDataAdapter dt = new SqlDataAdapter(cmd))
                {
                    cmd.Connection.Open();
                    DataTable tbl = new DataTable();
                    dt.Fill(tbl);
                    cmd.Connection.Close();
                    return tbl;
                }
            }
            else
                return new DataTable();
        }
        public DataTable loadRequestedBook(int i, string userid)
        {
            sqlDataAccess da = new sqlDataAccess();
            if (i == 0)
            {
                SqlCommand cmd = da.GetCommand("SELECT Bookname,authorname,pubyear FROM BookTable WHERE status = '" + "inactive" + "'");

                using (SqlDataAdapter dt = new SqlDataAdapter(cmd))
                {
                    cmd.Connection.Open();
                    DataTable tbl = new DataTable();
                    dt.Fill(tbl);
                    cmd.Connection.Close();
                    return tbl;
                }
            }
            else
                return new DataTable();
        }
        public int returnBook(BorrowInfo borrow,string review)
        {
            sqlDataAccess da = new sqlDataAccess();
            int val;
            double review1;
            int nopr;
            double temp;
            double temp2;
            SqlCommand cmd = da.GetCommand("Delete BorrowTable  where bookid ='" + borrow.bookId + "'and userid ='" + borrow.userId + "'");
            SqlCommand cmd1 = da.GetCommand("Select quantity,review,nopr from booktable where bookid ='" + borrow.bookId + "'");

            cmd1.Connection.Open();
            cmd1.ExecuteNonQuery();
            using (SqlDataAdapter dt = new SqlDataAdapter(cmd1))
            {
                DataTable tbl = new DataTable();
                dt.Fill(tbl);
                val = (int)tbl.Rows[0][0];
                temp2 = (double)tbl.Rows[0][1];
                review1 = (double)temp2;
                nopr = (int)tbl.Rows[0][2];
                cmd1.Connection.Close();
            }
            if (val >= 0)
            {


                val = val +1;
                temp= Convert.ToDouble(review);
                review1 = review1 + temp;
                nopr += 1;
                review1 = review1 /(double) nopr;

                SqlCommand cmd2 = da.GetCommand("UPDATE booktable SET  quantity='" + val + "', review='" + review1 + "', nopr='" + nopr + "' where bookid = '" + borrow.bookId + "'");
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                ///////////////////////////////////
                cmd2.Connection.Open();
                cmd2.ExecuteNonQuery();
                cmd2.Connection.Close();
                return 1;


            }
            else
            {
                cmd.Connection.Close();
                return 0;
            }
        }
        

    }
}
