using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class BorrowInfo
    {
        public int borrowId { get; set; }
        public string bookName { get; set; }
        public string authorName { get; set; }
        public int bookId { get; set; }
        public string userId { get; set; }
        public string borrowDate { get; set; }
        public string returnDate { get; set; }
    }
}
