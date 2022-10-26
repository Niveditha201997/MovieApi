using MovieData.Repository;
using MovieEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieBussiness.Services
{
    public class UserService
    {
        IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void Register(User users)
        {
            _userRepository.Register(users);
        }
        public User Login(User users)
        {
            return _userRepository.Login(users);
        }
    }
}
