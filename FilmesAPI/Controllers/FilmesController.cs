using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class FilmesController : ControllerBase
{

    private static List<Filme> filmes = new();
    private static int id = 0;


    [HttpPost]
    public ActionResult CadastrarFilme([FromBody] Filme filme)
    {
        filme.Id = ++id;
        Console.WriteLine(filme);
        filmes.Add(filme);
        return CreatedAtAction(nameof(BuscarFilme), new { id = filme.Id }, filme);
    }

    [HttpGet]
    public IActionResult ListarFilmes([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        var movies = filmes.Skip(skip).Take(take);
        return  Ok(movies);
    }

    [HttpGet("{id}")]
    public IActionResult BuscarFilme(int id)
    {
        var result = filmes.FirstOrDefault(f => f.Id == id);

        if (result == null)
        {
            return new NotFoundResult();
        }
        
        return Ok(result);
    }
}
