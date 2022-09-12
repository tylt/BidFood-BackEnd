using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using BidFood.Domain;
using BidFood.Infrastructure;

namespace BidFood.Application
{
    public class UserService : IUserService
    {
        private string _jsonFilePath;
        public UserService(string contentRootPath)
        {
            _jsonFilePath = contentRootPath + "/JsonData/user.json";
        }
        public async Task<User> Save(User user)
        {
            try
            {
                if (!(await IsUserExist(user)))
                    return await Insert(user);
                else
                    return await Update(user);
            }
            catch
            {
                throw;
            }
            
        }

        private async Task<bool> IsUserExist(User user)
        {
            try
            {
                JsonService jsonService = new JsonService();
                User[] users = await jsonService.ReadJSONAsync<User[]>(_jsonFilePath);
                return users.Where(x => x.Id == user.Id).FirstOrDefault() != null ? true : false;
            }
            catch
            {
                throw;
            }
        }

        private async Task<User> Insert(User user)
        {
            try
            {
                JsonService jsonService = new JsonService();
                var users = await jsonService.ReadJSONAsync<List<User>>(_jsonFilePath);
                users.Add(user);

                await jsonService.WriteJSONAsync(_jsonFilePath,users);
              
                return user;
            }
            catch
            {
                throw;
            }
        }

        private async Task<User> Update(User user)
        {
            try
            {
                JsonService jsonService = new JsonService();
                var users = await jsonService.ReadJSONAsync<List<User>>(_jsonFilePath);

                users.Where(u => u.Id == user.Id)
                        .ToList().ForEach
                        (
                          x =>
                          {
                              x.FirstName = user.FirstName;
                              x.LastName = user.LastName;
                          }
                        );

                await jsonService.WriteJSONAsync(_jsonFilePath, users);

                return user;
            }
            catch
            {
                throw;
            }
        }



    }
}
