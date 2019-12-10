using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class Book
    {
        public string BookName { get; set; }
        public string BookType { get; set; }
        public string BookID { get; set; }
        public string AuthorName { get; set; }
        public string PubYear { get; set; }
        public string Quantity { get; set; }
        public string Status { get; set; }
        public string ReviewPoint { get; set; }
    }

}