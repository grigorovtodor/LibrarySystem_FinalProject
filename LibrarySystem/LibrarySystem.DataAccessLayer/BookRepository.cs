using LibrarySystem.BusinessObjects;
using LibrarySystem.DatabaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DataAccessLayer
{
    public class BookRepository : IRepository<BookBusiness>
    {
        public void Create(BookBusiness item)
        {
            using (var database = new LibrarySystemDbEntities2())
            {
                var dbObject = Mapping.ConvertToDataEntity(item);
                database.Book.Add(dbObject);
                database.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var database = new LibrarySystemDbEntities2())
            {
                var dbBook = database.Book.FirstOrDefault(b => b.Id == id);
                
                if (dbBook.isDeleted != true)
                {
                    dbBook.isDeleted = true;
                }

                database.SaveChanges();
            }
        }

        public void Delete(BookBusiness item)
        {
            Delete(item.Id);
        }

        public BookBusiness Read(int id)
        {
            using (var database = new LibrarySystemDbEntities2())
            {
                var dbBook = database.Book.FirstOrDefault(b => b.Id == id);
                var result = Mapping.ConvertToBusinessEntity(dbBook);

                return result;
            }
        }

        public ICollection<BookBusiness> ReadAll()
        {
            using (var database = new LibrarySystemDbEntities2())
            {
                var dbBook = database.Book.Where(b => b.isDeleted == false).ToList();
                var result = new List<BookBusiness>();

                foreach (var book in dbBook)
                {
                    result.Add(Mapping.ConvertToBusinessEntity(book));
                }

                return result;
            }
        }

        public void Update(BookBusiness item)
        {
            using (var database = new LibrarySystemDbEntities2())
            {
                var dbBook = database.Book.FirstOrDefault(b => b.Id == item.Id);

                dbBook.Name = item.Name;
                dbBook.ISBN = item.ISBN;
                dbBook.countPages = item.countPages;
                dbBook.datePublished = item.datePublished;
                dbBook.isDeleted = item.isDeleted;
                dbBook.Author = Mapping.ConvertToDataEntity(item.Author);
                dbBook.Owner = Mapping.ConvertToDataEntity(item.Owner);

                database.SaveChanges();
            }
        }
    }
}
