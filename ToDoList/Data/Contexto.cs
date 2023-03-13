using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> opts) 
            : base(opts)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<ListaTarefa> ListaTarefas { get; set; }
    }
}
