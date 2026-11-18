using System;
using System.Collections.Generic;
using System.Text;

namespace Fsg.ProgramacaoOrientadaObjetos.GeradorProvas.Dominio;

public class Questao
{
    private readonly List<Alternativa> _alternativas;

    public int Id { get; }
    public string Disciplina { get; }
    public string Conteudo { get; }
    public string Enunciado { get; }

    public IReadOnlyList<Alternativa> Alternativas =>
        _alternativas.AsReadOnly();

    public Questao(
        int id,
        string disciplina,
        string conteudo,
        string enunciado,
        IEnumerable<Alternativa> alternativas)
    {
        if (string.IsNullOrWhiteSpace(disciplina))
            throw new RegraNegocioException("A disciplina é obrigatória.");

        if (string.IsNullOrWhiteSpace(conteudo))
            throw new RegraNegocioException("O conteúdo é obrigatório.");

        if (string.IsNullOrWhiteSpace(enunciado))
            throw new RegraNegocioException("O enunciado é obrigatório.");

        if (alternativas == null)
            throw new RegraNegocioException("As alternativas são obrigatórias.");

        List<Alternativa> listaAlternativas = alternativas.ToList();

        if (listaAlternativas.Count < 2 || listaAlternativas.Count > 5)
            throw new RegraNegocioException("A questão deve possuir entre 2 e 5 alternativas.");

        if (listaAlternativas.Count(a => a.Correta) != 1)
            throw new RegraNegocioException("A questão deve possuir exatamente uma alternativa correta.");

        Id = id;
        Disciplina = disciplina;
        Conteudo = conteudo;
        Enunciado = enunciado;

        _alternativas = listaAlternativas;
    }
}
