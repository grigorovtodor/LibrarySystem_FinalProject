using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.BusinessObjects
{
    public class OwnerBusiness
    {
        public OwnerBusiness()
        {
            //this.Book = new HashSet<BookBusiness>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string UniqueIdNumber { get; set; }
        public string Address { get; set; }
        public Nullable<byte> Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Nullable<bool> isDeleted { get; set; }

        //public ICollection<BookBusiness> Book { get; set; }
    }
}
