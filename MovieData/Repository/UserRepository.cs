using Microsoft.EntityFrameworkCore;
using MovieEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieData.Repository
{
    public class UserRepository : IUserRepository
    {
        AllDbContext _userDbcontext;
        public UserRepository(AllDbContext userDbcontext)
        {
            _userDbcontext = userDbcontext;
        }

        public User Login(User user)
        {
            User users = null;
            var result = _userDbcontext.users.Where(obj => obj.Email == user.Email && obj.Password == user.Password).ToList();
            if (result.Count > 0)
            {
                users = result[0];
            }
            return users;
        }

        public void Register(User users)
        {
            _userDbcontext.users.Add(users);
            _userDbcontext.SaveChanges();
        }
    }
}
