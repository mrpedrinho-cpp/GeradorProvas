using System;
using System.Collections.Generic;
using System.Text;
namespace Fsg.ProgramacaoOrientadaObjetos.GeradorProvas.Aplicacao;

public record QuestaoProvaDto(
    int Numero,
    string Enunciado,
    List<AlternativaDto> Alternativas
);