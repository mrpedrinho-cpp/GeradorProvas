using System;
using System.Collections.Generic;
using System.Text;
using Fsg.ProgramacaoOrientadaObjetos.GeradorProvas.Dominio;
namespace Fsg.ProgramacaoOrientadaObjetos.GeradorProvas.Aplicacao;

public class ServicoConsultaProva
{
    private readonly IRepositorioProvas _repositorio;

    public ServicoConsultaProva(
        IRepositorioProvas repositorio)
    {
        _repositorio = repositorio;
    }

    public ProvaDto ObterPorId(int id)
    {
        Prova? prova = _repositorio.ObterPorId(id);

        if (prova == null)
        {
            throw new RecursoNaoEncontradoException(
                $"Prova com ID {id} não encontrada.");
        }

        return MapeadorProva.ParaDto(prova);
    }
}