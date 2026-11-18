using System;
using System.Collections.Generic;
using System.Text;
namespace Fsg.ProgramacaoOrientadaObjetos.GeradorProvas.Aplicacao;

public record GeracaoProvaDto(
    string Nome,
    string Disciplina,
    List<string> Conteudos,
    int NumeroQuestoes
);