using System;
using System.Collections.Generic;
using System.Text;
using Fsg.ProgramacaoOrientadaObjetos.GeradorProvas.Dominio;
using Fsg.ProgramacaoOrientadaObjetos.GeradorProvas.Aplicacao;
namespace Fsg.ProgramacaoOrientadaObjetos.GeradorProvas.Infraestrutura;

public class RepositorioProvasEmMemoria : IRepositorioProvas
{
    private readonly List<Prova> _provas = new();
    private int _ultimoId;

    public int ObterProximoId()
    {
        _ultimoId++;
        return _ultimoId;
    }

    public void Adicionar(Prova prova)
    {
        _provas.Add(prova);
    }

    public Prova? ObterPorId(int id)
    {
        return _provas.FirstOrDefault(p => p.Id == id);
    }
}