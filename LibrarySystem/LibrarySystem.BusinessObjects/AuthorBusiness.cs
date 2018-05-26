using LibrarySystem.DatabaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.BusinessObjects
{
    public class AuthorBusiness
    {
        public AuthorBusiness()
        {
            //this.Book = new HashSet<BookBusiness>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<byte> Gender { get; set; }
        public Nullable<System.DateTime> Birthdate { get; set; }
        public Nullable<bool> isDeleted { get; set; }

        //public ICollection<BookBusiness> Book { get; set; }
    }
}
