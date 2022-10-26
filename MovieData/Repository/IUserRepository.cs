using MovieEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieData.Repository
{
    public interface IUserRepository
    {
        void Register(User users);
        User Login(User users);
    }
}
