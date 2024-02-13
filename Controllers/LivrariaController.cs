using app_livraria_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app_livraria_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrariaController : ControllerBase
    {
        private readonly TodoContext _context;

        public LivrariaController(TodoContext context)
        {
            _context = context;

            _context.TodoProdutos.Add(new Produto { ID = "1", Nome = "Book1", Preco = 24, Quant = 1, Categoria = "ação", Img = "Img1" });
            _context.TodoProdutos.Add(new Produto { ID = "2", Nome = "Book2", Preco = 50, Quant = 1, Categoria = "suspense", Img = "Img2" });
            _context.TodoProdutos.Add(new Produto { ID = "3", Nome = "Book3", Preco = 10, Quant = 2, Categoria = "drama", Img = "Img3" });
            _context.TodoProdutos.Add(new Produto { ID = "4", Nome = "Book4", Preco = 10, Quant = 1, Categoria = "ação", Img = "Img4" });
            _context.TodoProdutos.Add(new Produto { ID = "5", Nome = "Book5", Preco = 15, Quant = 5, Categoria = "ação", Img = "Img5" });
            _context.TodoProdutos.Add(new Produto { ID = "6", Nome = "Book6", Preco = 20, Quant = 8, Categoria = "técnico", Img = "Img6" });

            _context.SaveChanges();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            return await _context.TodoProdutos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            var item = await _context.TodoProdutos.FindAsync(id.ToString());

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduct(Produto produto)
        {
            _context.TodoProdutos.Add(produto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduto), new { id = produto.ID }, produto);
        }
    }
}
