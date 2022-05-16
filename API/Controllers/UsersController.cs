using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _datacontext;
        public UsersController(DataContext datacontext)
        {
            _datacontext = datacontext;
        }

        [HttpGet]
        public async Task<ActionResult<List<AppUser>>>GetUsers()
        {

            return await _datacontext.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>>GetUser(int id)
        {
            var user = _datacontext.Users.FindAsync(id);
            return await user;
        }
    }
}