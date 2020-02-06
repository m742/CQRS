


using ClassLibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class AppDbContext : DbContext
    {
       

        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options) 
        {
        }


        public DbSet<TodoItem> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // toda vez que executa esse model 
        { // ele passa por esse modulo
            modelBuilder.Entity<TodoItem>().Property(x => x.Id);
            modelBuilder.Entity<TodoItem>().Property(x => x.RefUser).HasMaxLength(120);
            modelBuilder.Entity<TodoItem>().Property(x => x.Title).HasMaxLength(120);
            modelBuilder.Entity<TodoItem>().Property(x => x.Done).HasMaxLength(120);
            modelBuilder.Entity<TodoItem>().Property(x => x.Date);
            modelBuilder.Entity<TodoItem>().HasIndex(b => b.RefUser);
        }


    }
}
