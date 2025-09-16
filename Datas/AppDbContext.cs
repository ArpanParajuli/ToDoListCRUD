using Microsoft.EntityFrameworkCore;
using ToDoListCRUD.Models;

namespace ToDoListCRUD.Datas
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<TaskList> TaskLists { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaskList>(entity =>
            {
                entity
                .HasOne(u => u.User)
                .WithMany(tl => tl.TaskLists)
                .HasForeignKey(u => u.UserId) // single user have multiple task
                .OnDelete(DeleteBehavior.Cascade); // if no user no task list 


                entity.HasData(
                      new TaskList
                      {
                          Id = 1,
                          Name = "Play deadshot",
                          Description = "Playing deadhot like pro",
                          UserId = 1

                      }
                    );
                
            });


            modelBuilder.Entity<User>(entity =>
            {

                entity.HasData(
                    new User { Id = 1, Email = "arpanparajuli@gmail.com", Name = "ArpanDev", Password = "ArpanDev123@" });

            });
        }


    }
}
