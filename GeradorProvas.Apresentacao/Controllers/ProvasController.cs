using Microsoft.AspNetCore.Mvc;
using Fsg.ProgramacaoOrientadaObjetos.GeradorProvas.Aplicacao;
using Fsg.ProgramacaoOrientadaObjetos.GeradorProvas.Dominio;
namespace Fsg.ProgramacaoOrientadaObjetos.GeradorProvas.Apresentacao.Controllers;

[ApiController]
[Route("provas")]
public class ProvasController : ControllerBase
{
    private readonly ServicoGeradorProva _servicoGerador;
    private readonly ServicoConsultaProva _servicoConsulta;

    public ProvasController(
        ServicoGeradorProva servicoGerador,
        ServicoConsultaProva servicoConsulta)
    {
        _servicoGerador = servicoGerador;
        _servicoConsulta = servicoConsulta;
    }

    [HttpPost]
    public IActionResult Gerar(
        [FromBody] GeracaoProvaDto dados)
    {
        try
        {
            ProvaDto prova = _servicoGerador.GerarProva(dados);

            return CreatedAtAction(
                nameof(Obter),
                new { id = prova.Id },
                prova
            );
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { mensagem = ex.Message });
        }
        catch (RegraNegocioException ex)
        {
            return UnprocessableEntity(new
            {
                mensagem = ex.Message
            });
        }
    }

    [HttpGet("{id:int}")]
    public IActionResult Obter(int id)
    {
        try
        {
            ProvaDto prova = _servicoConsulta.ObterPorId(id);

            return Ok(prova);
        }
        catch (RecursoNaoEncontradoException ex)
        {
            return NotFound(new { mensagem = ex.Message });
        }
    }
}