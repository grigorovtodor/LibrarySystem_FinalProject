using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibrarySystem.Web.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<byte> Gender { get; set; }
        public Nullable<System.DateTime> Birthdate { get; set; }
        public Nullable<bool> isDeleted { get; set; }
    }
}