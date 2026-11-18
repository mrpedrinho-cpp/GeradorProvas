using System;
using System.Collections.Generic;
using System.Text;
using Fsg.ProgramacaoOrientadaObjetos.GeradorProvas.Dominio;
namespace Fsg.ProgramacaoOrientadaObjetos.GeradorProvas.Aplicacao;

public static class MapeadorProva
{
    public static ProvaDto ParaDto(Prova prova)
    {
        List<QuestaoProvaDto> questoesDto = prova.Questoes
            .Select((questao, indice) =>
                new QuestaoProvaDto(
                    indice + 1,
                    questao.Enunciado,
                    questao.Alternativas
                        .Select((alternativa, index) =>
                            new AlternativaDto(
                                (char)('A' + index),
                                alternativa.Texto
                            )
                        )
                        .ToList()
                )
            )
            .ToList();

        return new ProvaDto(
            prova.Id,
            prova.Nome,
            prova.Disciplina,
            questoesDto
        );
    }
}