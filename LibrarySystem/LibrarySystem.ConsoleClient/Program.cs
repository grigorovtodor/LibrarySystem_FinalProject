using LibrarySystem.BusinessObjects;
using LibrarySystem.DataAccessLayer;
using LibrarySystem.DatabaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.ConsoleClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var db = new LibrarySystemDbEntities2();

            var author = db.Book.FirstOrDefault(b => b.Id == 3).Owner.Name;
            Console.WriteLine(author);


            var bookRepo = new BookRepository();
            var authorRepo = new AuthorRepository();
            var ownerRepo = new OwnerRepository();

            //var bookUpdate3 = bookRepo.Read(3);
            //var bookUpdate4 = bookRepo.Read(4);

            //bookUpdate3.isDeleted = false;
            //bookUpdate4.isDeleted = false;

            //bookRepo.Update(bookUpdate3);
            //bookRepo.Update(bookUpdate4);

            //var owner1 = new OwnerBusiness();
            //owner1.Name = "Alex Todorv";
            //owner1.Gender = 0;
            //owner1.Email = "alex@mail.bg";
            //owner1.Address = "Sofia, Druzhba 2";
            //owner1.UniqueIdNumber = "9406257845";
            //owner1.isDeleted = false;

            var book1 = new BookBusiness { Name = "Test book", ISBN = 122445667, countPages = 120, AuthorId = 12, OwnerId = 4 };

            //var author1 = new AuthorBusiness();
            //author1.Name = "Hristo Botev";
            //author1.isDeleted = false;
            //author1.Gender = 0;

            //var book3 = new BookBusiness { Name = "Pod Igoto", ISBN = 122445667, countPages = 230, Author = author1, Owner = new OwnerBusiness { Name = "Gosho Peshov", PhoneNumber = "08859494616", Email = "gosheto@abv.bg" } };


            bookRepo.Create(book1);
            //authorRepo.Create(author1);
            //bookRepo.Create(book3);
            //ownerRepo.Create(owner1);

        }
    }
}
