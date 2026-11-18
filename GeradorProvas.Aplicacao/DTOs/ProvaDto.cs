using System;
using System.Collections.Generic;
using System.Text;
namespace Fsg.ProgramacaoOrientadaObjetos.GeradorProvas.Aplicacao;

public record ProvaDto(
    int Id,
    string Nome,
    string Disciplina,
    List<QuestaoProvaDto> Questoes
);