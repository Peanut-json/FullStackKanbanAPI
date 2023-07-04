using FullStackKanbanAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FullStackKanbanAPI.Data
{
    public class FullStackKanBanDBContext : DbContext
    {
        public FullStackKanBanDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<KanBanEmployee> Employees { get; set; }
    }
} // setting the DB conext here  this will then set the table and the contents within 
  // using this I will then be able to setup a connection string for the final build setting 

  // using the options peram in the DB context so when we pass options to the class it dose the same to the BASE class also. 
