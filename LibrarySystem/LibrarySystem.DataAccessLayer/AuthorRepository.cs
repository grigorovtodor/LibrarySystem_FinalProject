using LibrarySystem.BusinessObjects;
using LibrarySystem.DatabaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DataAccessLayer
{
    public class AuthorRepository : IRepository<AuthorBusiness>
    {
        public void Create(AuthorBusiness item)
        {
            using (var database = new LibrarySystemDbEntities2())
            {
                var dbObject = Mapping.ConvertToDataEntity(item);
                database.Author.Add(dbObject);
                database.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var database = new LibrarySystemDbEntities2())
            {
                var dbAuthor = database.Author.FirstOrDefault(a => a.Id == id);

                if (dbAuthor.isDeleted != true)
                {
                    dbAuthor.isDeleted = true;
                }

                database.SaveChanges();
            }
        }

        public void Delete(AuthorBusiness item)
        {
            Delete(item.Id);
        }

        public AuthorBusiness Read(int id)
        {
            using (var database = new LibrarySystemDbEntities2())
            {
                var dbAuthor = database.Author.FirstOrDefault(a => a.Id == id);
                var result = Mapping.ConvertToBusinessEntity(dbAuthor);

                return result;
            }
        }

        public ICollection<AuthorBusiness> ReadAll()
        {
            using (var database = new LibrarySystemDbEntities2())
            {
                var dbAuthor = database.Author.Where(a => a.isDeleted == false).ToList();
                var result = new List<AuthorBusiness>();

                foreach (var author in dbAuthor)
                {
                    result.Add(Mapping.ConvertToBusinessEntity(author));
                }

                return result;
            }
        }

        public void Update(AuthorBusiness item)
        {
            using (var database = new LibrarySystemDbEntities2())
            {
                var dbAuthor = database.Author.FirstOrDefault(a => a.Id == item.Id);

                dbAuthor.Name = item.Name;
                dbAuthor.Birthdate = item.Birthdate;
                dbAuthor.Gender = item.Gender;
                dbAuthor.isDeleted = item.isDeleted;
                //dbAuthor.Book = new HashSet<Book>();

                //foreach (var book in item.Book)
                //{
                //    dbAuthor.Book.Add(Mapping.ConvertToDataEntity(book));
                //}
                
                database.SaveChanges();
            }
        }
    }
}
