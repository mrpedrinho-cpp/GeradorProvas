using System;
using System.Collections.Generic;
using System.Text;

namespace Fsg.ProgramacaoOrientadaObjetos.GeradorProvas.Dominio;

public class Prova
{
    private readonly List<Questao> _questoes;

    public int Id { get; }
    public string Nome { get; }
    public string Disciplina { get; }

    public IReadOnlyList<Questao> Questoes =>
        _questoes.AsReadOnly();

    public Prova(
        int id,
        string nome,
        string disciplina,
        IEnumerable<Questao> questoes)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new RegraNegocioException("O nome da prova é obrigatório.");

        if (string.IsNullOrWhiteSpace(disciplina))
            throw new RegraNegocioException("A disciplina da prova é obrigatória.");

        if (questoes == null)
            throw new RegraNegocioException("A prova precisa possuir questões.");

        List<Questao> listaQuestoes = questoes.ToList();

        if (listaQuestoes.Count == 0)
            throw new RegraNegocioException("A prova precisa possuir pelo menos uma questão.");

        if (listaQuestoes.Select(q => q.Id).Distinct().Count()
            != listaQuestoes.Count)
        {
            throw new RegraNegocioException("A prova não pode possuir questões repetidas.");
        }

        Id = id;
        Nome = nome;
        Disciplina = disciplina;

        _questoes = listaQuestoes;
    }
}
