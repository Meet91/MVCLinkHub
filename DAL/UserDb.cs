using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDb
    {
          private LinkHubDbEntities db;

        public UserDb()
        {
            db = new LinkHubDbEntities();
        }

        public IEnumerable<tbl_User> GetAll()
        {
            return db.tbl_User.ToList();
        }

        public tbl_User GetById(int Id)
        {
            return db.tbl_User.Find(Id);
        }

        public void Insert(tbl_User User)
        {
            db.tbl_User.Add(User);
            Save();
        }

        public void Delete(int Id)
        {
            tbl_User User = db.tbl_User.Find(Id);
            db.tbl_User.Remove(User);
            Save();
        }

        public void Update(tbl_User User)
        {
            db.Entry(User).State = EntityState.Modified;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
