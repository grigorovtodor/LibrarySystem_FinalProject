using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.BusinessObjects;
using LibrarySystem.DatabaseEntity;


namespace LibrarySystem.DataAccessLayer
{
    public static class Mapping
    {
        public static BookBusiness ConvertToBusinessEntity(Book book)
        {
            var businessObject = new BookBusiness();
            businessObject.Id = book.Id;
            businessObject.Name = book.Name;
            businessObject.ISBN = book.ISBN;
            businessObject.countPages = book.countPages;
            businessObject.datePublished = (DateTime)book.datePublished;
            businessObject.Author = Mapping.ConvertToBusinessEntity(book.Author);
            businessObject.Owner = Mapping.ConvertToBusinessEntity(book.Owner);
            businessObject.isDeleted = book.isDeleted;

            return businessObject;
        }

        public static Book ConvertToDataEntity(BookBusiness book)
        {
            var dataObject = new Book();
            dataObject.Id = book.Id;
            dataObject.Name = book.Name;
            dataObject.ISBN = book.ISBN;
            dataObject.countPages = book.countPages;
            dataObject.datePublished = (DateTime)book.datePublished;
            dataObject.Author = Mapping.ConvertToDataEntity(book.Author);
            dataObject.Owner = Mapping.ConvertToDataEntity(book.Owner);
            dataObject.isDeleted = book.isDeleted;

            return dataObject;
        }


        public static AuthorBusiness ConvertToBusinessEntity(Author author)
        {
            var businessObject = new AuthorBusiness();
            businessObject.Id = author.Id;
            businessObject.Name = author.Name;
            businessObject.Gender = author.Gender;
            if (author.Birthdate != null)
            {
                businessObject.Birthdate = (DateTime)author.Birthdate;
            }
            
            //businessObject.Book = new HashSet<BookBusiness>();
            businessObject.isDeleted = author.isDeleted;

            //foreach (var item in author.Book)
            //{
            //    businessObject.Book.Add(Mapping.ConvertToBusinessEntity(item));
            //}
            
            return businessObject;
        }

        public static Author ConvertToDataEntity(AuthorBusiness author)
        {
            var dataObject = new Author();
            dataObject.Id = author.Id;
            dataObject.Name = author.Name;
            dataObject.Gender = author.Gender;
            if (author.Birthdate != null)
            {
                dataObject.Birthdate = (DateTime)author.Birthdate;
            }
            
            //dataObject.Book = new HashSet<Book>();
            dataObject.isDeleted = author.isDeleted;

            //foreach (var item in author.Book)
            //{
            //    dataObject.Book.Add(Mapping.ConvertToDataEntity(item));
            //}

            return dataObject;
        }

        public static OwnerBusiness ConvertToBusinessEntity(Owner owner)
        {
            var businessObject = new OwnerBusiness();
            businessObject.Id = owner.Id;
            businessObject.Name = owner.Name;
            businessObject.Gender = owner.Gender;
            businessObject.Address = owner.Address;
            businessObject.Email = owner.Email;
            businessObject.UniqueIdNumber = owner.UniqueIdNumber;
            //businessObject.Book = new HashSet<BookBusiness>();
            businessObject.isDeleted = owner.isDeleted;

            //foreach (var item in owner.Book)
            //{
            //    businessObject.Book.Add(Mapping.ConvertToBusinessEntity(item));
            //}

            return businessObject;
        }

        public static Owner ConvertToDataEntity(OwnerBusiness owner)
        {
            var dataObject = new Owner();
            dataObject.Id = owner.Id;
            dataObject.Name = owner.Name;
            dataObject.Gender = owner.Gender;
            dataObject.Address = owner.Address;
            dataObject.Email = owner.Email;
            dataObject.UniqueIdNumber = owner.UniqueIdNumber;
            //dataObject.Book = new HashSet<Book>();
            dataObject.isDeleted = owner.isDeleted;

            //foreach (var item in owner.Book)
            //{
            //    dataObject.Book.Add(Mapping.ConvertToDataEntity(item));
            //}

            return dataObject;
        }
    }
}
