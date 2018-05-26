using LibrarySystem.BusinessObjects;
using LibrarySystem.DatabaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DataAccessLayer
{
    public class OwnerRepository : IRepository<OwnerBusiness>
    {
        public void Create(OwnerBusiness item)
        {
            using (var database = new LibrarySystemDbEntities2())
            {
                var dbObject = Mapping.ConvertToDataEntity(item);
                database.Owner.Add(dbObject);
                database.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var database = new LibrarySystemDbEntities2())
            {
                var dbOwner = database.Owner.FirstOrDefault(o => o.Id == id);

                if (dbOwner.isDeleted != true)
                {
                    dbOwner.isDeleted = true;
                }

                database.SaveChanges();
            }
        }

        public void Delete(OwnerBusiness item)
        {
            Delete(item);
        }

        public OwnerBusiness Read(int id)
        {
            using (var database = new LibrarySystemDbEntities2())
            {
                var dbOwner = database.Owner.FirstOrDefault(o => o.Id == id);
                var result = Mapping.ConvertToBusinessEntity(dbOwner);

                return result;
            }
        }

        public ICollection<OwnerBusiness> ReadAll()
        {
            using (var database = new LibrarySystemDbEntities2())
            {
                var dbOwner = database.Owner.Where(o => o.isDeleted == false).ToList();
                var result = new List<OwnerBusiness>();

                foreach (var owner in dbOwner)
                {
                    result.Add(Mapping.ConvertToBusinessEntity(owner));
                }

                return result;
            }
        }

        public void Update(OwnerBusiness item)
        {
            using (var database = new LibrarySystemDbEntities2())
            {
                var dbOwner = database.Owner.FirstOrDefault(a => a.Id == item.Id);

                dbOwner.Name = item.Name;
                dbOwner.Email = item.Email;
                dbOwner.Address = item.Address;
                dbOwner.PhoneNumber = item.PhoneNumber;
                dbOwner.UniqueIdNumber = item.UniqueIdNumber;
                dbOwner.Gender = item.Gender;
                dbOwner.isDeleted = item.isDeleted;
                
                database.SaveChanges();
            }
        }
    }
}
