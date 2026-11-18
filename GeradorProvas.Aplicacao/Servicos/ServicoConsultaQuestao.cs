using System;
using System.Collections.Generic;
using System.Text;
using Fsg.ProgramacaoOrientadaObjetos.GeradorProvas.Dominio;
namespace Fsg.ProgramacaoOrientadaObjetos.GeradorProvas.Aplicacao;

public class ServicoConsultaQuestao
{
    private readonly IRepositorioQuestoes _repositorio;

    public ServicoConsultaQuestao(
        IRepositorioQuestoes repositorio)
    {
        _repositorio = repositorio;
    }

    public QuestaoDto ObterPorId(int id)
    {
        Questao? questao = _repositorio.ObterPorId(id);

        if (questao == null)
        {
            throw new RecursoNaoEncontradoException($"Questão com ID {id} não encontrada.");
        }

        return ParaDto(questao);
    }

    public List<QuestaoDto> Listar(
        string disciplina,
        string? conteudo)
    {
        return _repositorio.Listar(disciplina, conteudo)
            .Select(ParaDto)
            .ToList();
    }

    private static QuestaoDto ParaDto(Questao questao)
    {
        List<AlternativaDto> alternativas = questao.Alternativas
            .Select((alternativa, indice) =>
                new AlternativaDto(
                    (char)('A' + indice),
                    alternativa.Texto
                )
            )
            .ToList();

        int indiceCorreta = questao.Alternativas
            .ToList()
            .FindIndex(a => a.Correta);

        return new QuestaoDto(
            questao.Id,
            questao.Disciplina,
            questao.Conteudo,
            questao.Enunciado,
            alternativas,
            (char)('A' + indiceCorreta)
        );
    }
}