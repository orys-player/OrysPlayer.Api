using Microsoft.AspNetCore.Mvc;

namespace OrysPlayerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private static readonly List<User> Users =
    [
        new User { Id = 1, Firstname = "John", Lastname = "Doe", Email = "john.doe@gmail.com", Password = "password" },
        new User { Id = 2, Firstname = "Jane", Lastname = "Doe", Email = "jane.doe@gmail.com", Password = "password" },
        new User { Id = 3, Firstname = "Jim", Lastname = "Beam", Email = "jim.beam@gmail.com", Password = "password" }
    ];

    [HttpGet]
    public ActionResult<List<User>> GetUsers()
    {
        return Ok(Users);
    }

    [HttpGet]
    [Route("{id:int}")]
    public ActionResult<User> GetUser(int id)
    {
        var user = Users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }
}