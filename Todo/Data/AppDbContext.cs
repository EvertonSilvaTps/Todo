using Microsoft.EntityFrameworkCore;
using Todo.API.Models;

namespace Todo.API.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TodoModel> Todos { get; set; }   // DbSet = Criação de tabela do banco

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=todosApp.db");  // Conection com o banco 
        }


    }
}
