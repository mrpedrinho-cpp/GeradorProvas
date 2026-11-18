using System;
using System.Collections.Generic;
using System.Text;
namespace Fsg.ProgramacaoOrientadaObjetos.GeradorProvas.Aplicacao;

public record CadastroQuestaoDto(
    string Disciplina,
    string Conteudo,
    string Enunciado,
    List<AlternativaCadastroDto> Alternativas
);