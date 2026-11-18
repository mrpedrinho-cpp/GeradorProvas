using System;
using System.Collections.Generic;
using System.Text;
using Fsg.ProgramacaoOrientadaObjetos.GeradorProvas.Dominio;
namespace Fsg.ProgramacaoOrientadaObjetos.GeradorProvas.Aplicacao;

public class ServicoGeradorProva
{
    private readonly IRepositorioQuestoes _repositorioQuestoes;
    private readonly IRepositorioProvas _repositorioProvas;
    private readonly IEmbaralhador _embaralhador;

    public ServicoGeradorProva(
        IRepositorioQuestoes repositorioQuestoes,
        IRepositorioProvas repositorioProvas,
        IEmbaralhador embaralhador)
    {
        _repositorioQuestoes = repositorioQuestoes;
        _repositorioProvas = repositorioProvas;
        _embaralhador = embaralhador;
    }

    public ProvaDto GerarProva(GeracaoProvaDto dados)
    {
        if (string.IsNullOrWhiteSpace(dados.Nome))
            throw new RegraNegocioException("O nome da prova é obrigatório.");

        if (string.IsNullOrWhiteSpace(dados.Disciplina))
            throw new RegraNegocioException("A disciplina é obrigatória.");

        if (dados.Conteudos == null || dados.Conteudos.Count == 0)
            throw new RegraNegocioException("Informe pelo menos um conteúdo.");

        if (dados.NumeroQuestoes <= 0)
            throw new RegraNegocioException("O número de questões deve ser maior que zero.");

        IReadOnlyList<Questao> questoesDisponiveis =
            _repositorioQuestoes.Filtrar(
                dados.Disciplina,
                dados.Conteudos
            );

        if (questoesDisponiveis.Count < dados.NumeroQuestoes)
        {
            throw new RegraNegocioException(
                $"Não existem questões suficientes. " +
                $"Disponíveis: {questoesDisponiveis.Count}. " +
                $"Solicitadas: {dados.NumeroQuestoes}."
            );
        }

        List<Questao> questoesEmbaralhadas =
            _embaralhador.Embaralhar(questoesDisponiveis);

        List<Questao> questoesSelecionadas =
            questoesEmbaralhadas
                .Take(dados.NumeroQuestoes)
                .ToList();

        int id = _repositorioProvas.ObterProximoId();

        Prova prova = new Prova(
            id,
            dados.Nome,
            dados.Disciplina,
            questoesSelecionadas
        );

        _repositorioProvas.Adicionar(prova);

        return MapeadorProva.ParaDto(prova);
    }
}