using System;
using System.Collections.Generic;
using System.Text;
using Fsg.ProgramacaoOrientadaObjetos.GeradorProvas.Dominio;
using Fsg.ProgramacaoOrientadaObjetos.GeradorProvas.Aplicacao;
namespace Fsg.ProgramacaoOrientadaObjetos.GeradorProvas.Infraestrutura;

public class RepositorioQuestoesEmMemoria : IRepositorioQuestoes
{
    private readonly List<Questao> _questoes = new();
    private int _ultimoId;

    public int ObterProximoId()
    {
        _ultimoId++;
        return _ultimoId;
    }

    public void Adicionar(Questao questao)
    {
        _questoes.Add(questao);
    }

    public Questao? ObterPorId(int id)
    {
        return _questoes.FirstOrDefault(q => q.Id == id);
    }

    public IReadOnlyList<Questao> Listar(
        string disciplina,
        string? conteudo)
    {
        return _questoes
            .Where(q =>
                q.Disciplina.Equals(
                    disciplina,
                    StringComparison.OrdinalIgnoreCase))
            .Where(q =>
                string.IsNullOrWhiteSpace(conteudo) ||
                q.Conteudo.Equals(
                    conteudo,
                    StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public IReadOnlyList<Questao> Filtrar(
        string disciplina,
        IReadOnlyList<string> conteudos)
    {
        return _questoes
            .Where(q =>
                q.Disciplina.Equals(
                    disciplina,
                    StringComparison.OrdinalIgnoreCase))
            .Where(q =>
                conteudos.Contains(
                    q.Conteudo,
                    StringComparer.OrdinalIgnoreCase))
            .ToList();
    }
}