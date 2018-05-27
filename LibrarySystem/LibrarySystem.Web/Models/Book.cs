using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibrarySystem.Web.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ISBN { get; set; }
        public int? countPages { get; set; }
        public DateTime datePublished { get; set; }
        public int AuthorId { get; set; }
        public int OwnerId { get; set; }
        public Nullable<bool> isDeleted { get; set; }

        public Author Author { get; set; }
        public Owner Owner { get; set; }
    }
}