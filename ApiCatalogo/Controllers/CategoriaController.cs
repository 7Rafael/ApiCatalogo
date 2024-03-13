using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriaController : ControllerBase
{

    private readonly AppDbContext _context;

    public CategoriaController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("Categorias")]
    public ActionResult<IEnumerable<Categoria>> GetAll()
    {
        var categorias = _context.Categorias.Take(10).AsNoTracking().ToList();
        if (categorias is null)
        {
            return NotFound();
        }
        return categorias;
    }
    
    [HttpGet("{id:int}", Name = "ObterCategoria")]
    public ActionResult<Categoria> GetById(int id)
    {
        var categorias = _context.Categorias.AsNoTracking().FirstOrDefault(c => c.CategoriaId == id);
        if (categorias is null)
        {
            return NotFound();
        }
        return categorias;
    }

    [HttpGet("Produtos")]
    public ActionResult<IEnumerable<Categoria>> GetAllProdutosECategorias()
    {

        return _context.Categorias.Include(p => p.Produtos).Where(c=>c.CategoriaId <= 10).AsNoTracking().ToList();
    }

    [HttpPost("Categorias")]
    public ActionResult Post(Categoria categoria)
    {
        if (categoria is null)
        {
            return BadRequest();
        }
        _context.Categorias.Add(categoria);
        _context.SaveChanges();

        return new CreatedAtRouteResult("ObterCategoria",
            new { id = categoria.CategoriaId }, categoria);
    }
    
    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Categoria categoria)
    {

        if(id != categoria.CategoriaId)
        {
            return BadRequest();
        }
        _context.Entry(categoria).State = EntityState.Modified;
        _context.SaveChanges();
        return Ok(categoria);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var categoria = _context.Categorias.FirstOrDefault(c => c.CategoriaId == id);
        if (categoria is null)
        {
            return NotFound("Categoria não encontrado");
        }
        _context.Categorias.Remove(categoria);
        _context.SaveChanges();
        return Ok(categoria);

    }

}

