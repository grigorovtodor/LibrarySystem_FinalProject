using LibrarySystem.DatabaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.BusinessObjects
{
    public class BookBusiness
    {
        public BookBusiness()
        {

        }

        public BookBusiness(string name, int iSBN)
        {
            this.Name = name;
            this.ISBN = ISBN;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ISBN { get; set; }
        public int? countPages { get; set; }
        public DateTime datePublished { get; set; }
        public int AuthorId { get; set; }
        public int OwnerId { get; set; }
        public Nullable<bool> isDeleted { get; set; }

        public AuthorBusiness Author { get; set; }
        public OwnerBusiness Owner { get; set; }
    }
}
