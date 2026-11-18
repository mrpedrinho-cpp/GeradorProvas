using System;
using System.Collections.Generic;
using System.Text;
using Fsg.ProgramacaoOrientadaObjetos.GeradorProvas.Dominio;
namespace Fsg.ProgramacaoOrientadaObjetos.GeradorProvas.Aplicacao;

public interface IRepositorioQuestoes
{
    int ObterProximoId();

    void Adicionar(Questao questao);

    Questao? ObterPorId(int id);

    IReadOnlyList<Questao> Listar(
        string disciplina,
        string? conteudo);

    IReadOnlyList<Questao> Filtrar(
        string disciplina,
        IReadOnlyList<string> conteudos);
}
