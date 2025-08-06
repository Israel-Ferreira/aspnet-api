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
        return Created();
    }

    [HttpGet]
    public IEnumerable<Filme> ListarFilmes()
    {
        return filmes;
    }

    [HttpGet("{id}")]
    public ActionResult<Filme> BuscarFilme(int id)
    {
        var result = filmes.FirstOrDefault(f => f.Id == id);

        if (result == null)
        {
            return new NotFoundResult();
        }
        
        return Ok(result);
    }
}
