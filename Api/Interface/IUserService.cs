using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Interface
{
    public interface IUserService 
    {
        public User Authenticate(User user);

        public IEnumerable<User> GetAll(int pageIndex = 0, int pageSize = int.MaxValue);

        public User GetUser(int id);

        public User Create(User user);

    }
}
