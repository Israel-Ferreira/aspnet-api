using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class FilmesController : ControllerBase
{

    private static List<Filme> filmes = new();


    [HttpPost]
    public void CadastrarFilme(Filme filme)
    {
        filmes.Add(filme);
    }

    [HttpGet]
    public List<Filme> ListarFilmes()
    {
        return filmes;
    }
}
