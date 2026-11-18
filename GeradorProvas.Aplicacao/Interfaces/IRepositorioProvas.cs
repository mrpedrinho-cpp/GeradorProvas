using System;
using System.Collections.Generic;
using System.Text;
using Fsg.ProgramacaoOrientadaObjetos.GeradorProvas.Dominio;
namespace Fsg.ProgramacaoOrientadaObjetos.GeradorProvas.Aplicacao;

public interface IRepositorioProvas
{
    int ObterProximoId();

    void Adicionar(Prova prova);

    Prova? ObterPorId(int id);
}