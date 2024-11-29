using LibaryMangement.DL.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibaryMangement.DL.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
    {

    }

    public DbSet<BookEntity> Books { get; set; }

    public DbSet<MemberEntity> Members { get; set; }
}
