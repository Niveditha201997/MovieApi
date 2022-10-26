using Microsoft.EntityFrameworkCore;
using MovieEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieData
{
    public class UserOperations
    {
        AllDbContext db = null;
        public UserOperations(AllDbContext db)
        {
            this.db = db;
        }
        public string AddUser(User users)
        {
            db = new AllDbContext();
            db.users.Add(users);
            db.SaveChanges();
            return "Saved";
        }
        public string UpdateUser(User users)
        {
            db = new AllDbContext();
            db.Entry(users).State = EntityState.Modified;
            db.SaveChanges();
            return "Updated";
        }
        public string DeleteUser(User usersId)
        {
            db = new AllDbContext();
            User usersobj = db.users.Find(usersId);
            db.Entry(usersobj).State = EntityState.Deleted;
            db.SaveChanges();
            return "Deleted";
        }
        public List<User> ShowAll()
        {
            db = new AllDbContext();
            List<User> usersList = db.users.ToList();
            return usersList;
        }

        public User ShowShowUserById(int usersId)
        {
            db = new AllDbContext();
            User users = db.users.Find(usersId);
            return new User();
        }
    }
}
