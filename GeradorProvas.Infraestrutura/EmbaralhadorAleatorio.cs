using System;
using System.Collections.Generic;
using System.Text;
using Fsg.ProgramacaoOrientadaObjetos.GeradorProvas.Dominio;
using Fsg.ProgramacaoOrientadaObjetos.GeradorProvas.Aplicacao;
namespace Fsg.ProgramacaoOrientadaObjetos.GeradorProvas.Infraestrutura;

public class EmbaralhadorAleatorio : IEmbaralhador
{
    private readonly Random _aleatorio;

    public EmbaralhadorAleatorio(Random aleatorio)
    {
        _aleatorio = aleatorio;
    }

    public List<Questao> Embaralhar(
        IReadOnlyList<Questao> questoes)
    {
        List<Questao> resultado = questoes.ToList();

        for (int i = resultado.Count - 1; i > 0; i--)
        {
            int indiceAleatorio = _aleatorio.Next(i + 1);

            (resultado[i], resultado[indiceAleatorio]) =
                (resultado[indiceAleatorio], resultado[i]);
        }

        return resultado;
    }
}