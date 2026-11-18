using System;
using System.Collections.Generic;
using System.Text;

namespace Fsg.ProgramacaoOrientadaObjetos.GeradorProvas.Dominio;
public class Alternativa
{
    public string Texto { get; }
    public bool Correta { get; }

    public Alternativa(string texto, bool correta)
    {
        if (string.IsNullOrWhiteSpace(texto))
            throw new RegraNegocioException("O texto da alternativa não pode ser nulo ou vazio.");

        Texto = texto;
        Correta = correta;
    }
}