using app_livraria_backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app_livraria_backend.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> option)
             : base(option)
        {
        }

        public DbSet<Produto> TodoProdutos { get; set; }
    }
}