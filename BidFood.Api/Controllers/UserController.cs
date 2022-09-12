using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using BidFood.Domain;
using BidFood.Application;
using Microsoft.AspNetCore.Cors;

namespace BidFood.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        //public UserController(IConfiguration configuration, ICommon common,ILogger<UserController> logger)
        public UserController(IConfiguration configuration,IUserService userService, ILogger<UserController> logger)
        {
            _logger = logger;
            _config = configuration;
            _userService = userService;
        }

        [EnableCors]
        [HttpPost]
        public async Task<User> Post(User data)
        {
           try
           {
                return await _userService.Save(data);
           }
           catch (Exception ex)
           {
                 _logger.LogError(ex, ex.Message);
                throw;
           }
        }
    }
}
