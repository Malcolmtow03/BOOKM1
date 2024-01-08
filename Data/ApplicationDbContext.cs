using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BOOKM1.Models;

namespace BOOKM1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BOOKM1.Models.Author> Author { get; set; } = default!;
        public DbSet<BOOKM1.Models.Books> Books { get; set; } = default!;
        public DbSet<BOOKM1.Models.Study> Study { get; set; } = default!;
    }
}