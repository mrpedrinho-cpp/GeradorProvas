using System;
using System.Collections.Generic;
using System.Text;
using Fsg.ProgramacaoOrientadaObjetos.GeradorProvas.Dominio;
namespace Fsg.ProgramacaoOrientadaObjetos.GeradorProvas.Aplicacao;

public class ServicoCadastroQuestao
{
    private readonly IRepositorioQuestoes _repositorio;

    public ServicoCadastroQuestao(
        IRepositorioQuestoes repositorio)
    {
        _repositorio = repositorio;
    }

    public int Cadastrar(CadastroQuestaoDto dados)
    {
        int id = _repositorio.ObterProximoId();

        List<Alternativa> alternativas = dados.Alternativas
            .Select(a => new Alternativa(a.Texto, a.Correta))
            .ToList();

        Questao questao = new Questao(
            id,
            dados.Disciplina,
            dados.Conteudo,
            dados.Enunciado,
            alternativas
        );

        _repositorio.Adicionar(questao);

        return id;
    }
}