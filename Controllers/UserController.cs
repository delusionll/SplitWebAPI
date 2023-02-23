using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SplitWebAPI.DataBase;
using SplitWebAPI.Models;

namespace SplitWebAPI.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
        //[HttpGet("/GetUserById")]
        //public async Task GetUserById()
        //{
        //    Response.ContentType = "text/html; charset=utf-8";
        //    string content = @"<form method = 'get'>
        //                    <label>Id: </label><br />
        //                    <input name = 'id' /<br /
        //                    <input type='number' value=''/> </form>";
        //    await Response.WriteAsync(content);
        //}
        [HttpGet("/GetUserById")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            using (SplitContext _db = new())
            {
                User user = await _db.Users.FirstOrDefaultAsync(u => u.UserId == id);
                if (user == null)
                {
                    return NotFound();
                }
                return new ObjectResult(user);
            }
        }

        [HttpGet]
        [Route("/NewUser")]
        public async Task NewUser()
        {
            Response.ContentType = "text/html; charset=utf-8";
            string content = @"<form method = 'post'>
                            <label>Name: </label><br />
                            <input name = 'username' /<br /
                            <input type='text' value=''/> </form>";
            await Response.WriteAsync(content);
        }

        [HttpPost("/NewUser")]
        public async Task<ActionResult<User>> Post(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            using (SplitContext _db = new())
            {
                _db.Users.Add(user);
                await _db.SaveChangesAsync();
                return Ok(user);
            }
        }

        [HttpDelete("/DeleteAllUsers")]
        public async Task DeleteAllUsers()
        {
            SplitContext.DeleteAllUsers();
            await Response.WriteAsync("All users are deleted.");
        }

        [HttpGet("/DeleteUserById")]
        public async Task DeleteUserById()
        {
            Response.ContentType = "text/html; charset=utf-8";
            string content = @"<form method = 'post'>
                            <label>UserId: </label><br />
                            <input name = 'userid' /<br /
                            <input type='number' value='Enter User ID (int)'/> </form>";
            await Response.WriteAsync(content);
        }

        [HttpDelete("/DeleteUserById")]
        public string DeleteUserById([FromForm] int userid)
        {
            if (SplitContext.GetUserById(userid) != null)
            {
                int otvet = SplitContext.GetUserById(userid).UserId;
                SplitContext.DeleteUserById(userid);
                return $"User with {otvet} id removed from DB";
            }
            else
            {
                return "User not found";
            }
        }
    }
}