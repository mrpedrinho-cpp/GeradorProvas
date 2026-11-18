using Microsoft.AspNetCore.Mvc;
using Fsg.ProgramacaoOrientadaObjetos.GeradorProvas.Aplicacao;
namespace Fsg.ProgramacaoOrientadaObjetos.GeradorProvas.Apresentacao.Controllers;

[ApiController]
[Route("questoes")]
public class QuestoesController : ControllerBase
{
    private readonly ServicoCadastroQuestao _servicoCadastro;
    private readonly ServicoConsultaQuestao _servicoConsulta;

    public QuestoesController(
        ServicoCadastroQuestao servicoCadastro,
        ServicoConsultaQuestao servicoConsulta)
    {
        _servicoCadastro = servicoCadastro;
        _servicoConsulta = servicoConsulta;
    }

    [HttpPost]
    public IActionResult Cadastrar(
        [FromBody] CadastroQuestaoDto dados)
    {
        try
        {
            int id = _servicoCadastro.Cadastrar(dados);

            return CreatedAtAction(
                nameof(Obter),
                new { id },
                new { id }
            );
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { mensagem = ex.Message });
        }
    }

    [HttpGet("{id:int}")]
    public IActionResult Obter(int id)
    {
        try
        {
            QuestaoDto questao = _servicoConsulta.ObterPorId(id);

            return Ok(questao);
        }
        catch (RecursoNaoEncontradoException ex)
        {
            return NotFound(new { mensagem = ex.Message });
        }
    }

    [HttpGet]
    public IActionResult Listar(
        [FromQuery] string disciplina,
        [FromQuery] string? conteudo)
    {
        if (string.IsNullOrWhiteSpace(disciplina))
            return BadRequest(new
            {
                mensagem = "A disciplina é obrigatória."
            });

        List<QuestaoDto> questoes =
            _servicoConsulta.Listar(disciplina, conteudo);

        return Ok(questoes);
    }
}