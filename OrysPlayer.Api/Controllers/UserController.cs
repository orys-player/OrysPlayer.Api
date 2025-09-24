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

    [HttpPost]
    public ActionResult<User> CreateUser(User newUser)
    {
        if (newUser is null) return BadRequest();
        newUser.Id = Users.Max(u => u.Id) + 1;
        Users.Add(newUser);
        return CreatedAtAction(nameof(GetUser), new { id = newUser.Id }, newUser);
    }

    [HttpPut]
    [Route("{id:int}")]
    public IActionResult UpdateUser(int id, User updatedUser)
    {
        var game = Users.FirstOrDefault(u => u.Id == id);
        
        if (game is null) return NotFound();
        
        game.Firstname = updatedUser.Firstname;
        game.Lastname = updatedUser.Lastname;
        game.Email = updatedUser.Email;
        game.Password = updatedUser.Password;
        
        return NoContent();
    }

    [HttpDelete]
    [Route("{id:int}")]
    public IActionResult DeleteUser(int id)
    {
        var user = Users.FirstOrDefault(u => u.Id == id);
        if (user is null) return NotFound();
        Users.Remove(user);
        return NoContent();
    }
}