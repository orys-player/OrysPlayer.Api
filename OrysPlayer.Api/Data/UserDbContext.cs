using Microsoft.EntityFrameworkCore;

namespace OrysPlayerApi.Data;

public class UserDbContext(DbContextOptions<UserDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
}