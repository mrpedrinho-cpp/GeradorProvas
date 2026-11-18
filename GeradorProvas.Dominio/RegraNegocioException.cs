using System;
using System.Collections.Generic;
using System.Text;

namespace Fsg.ProgramacaoOrientadaObjetos.GeradorProvas.Dominio;

public class RegraNegocioException : Exception{
    public RegraNegocioException(string mensagem) : base(mensagem){
    }
}