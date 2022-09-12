using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using BidFood.Domain;

namespace BidFood.Application
{
    public interface IUserService
    {
        Task<User> Save(User user);
    }
}
