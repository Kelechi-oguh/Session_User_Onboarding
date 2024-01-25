using Microsoft.EntityFrameworkCore;
using Session_User_Onboarding.Models;

namespace Session_User_Onboarding.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Session> Sessions { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Session>()
                .HasMany(s => s.Departments)
                .WithOne(d => d.Session)
                .HasForeignKey(d => d.SessionId);

            /*Here's what each part does:

            1=> modelBuilder.Entity<Session>(): This part indicates that you're configuring the 
            properties of the Session entity in the database.

            2=> .HasMany(s => s.Departments): This part specifies that a Session can have many Departments. 
            It defines a one-to-many relationship between the Session entity and the Department entity.

            3=> .WithOne(d => d.Session): This part indicates that each Department belongs to one Session. 
            It establishes the reverse navigation from Department back to Session.

            4=> .HasForeignKey(d => d.SessionId): This part sets up the foreign key relationship. 
            It states that the SessionId property in the Department entity will be used as a foreign key to 
            link it back to the primary key (Id) of the Session entity.*/
        }
    }
}
