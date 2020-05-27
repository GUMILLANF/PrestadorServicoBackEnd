using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PrestadorServico.Domain.Entities;
using PrestadorServico.Domain.Repositories;
using PrestadorServico.Infra.Context;
using System.Linq;

namespace PrestadorServico.Infra.Repositories
{
  public class ServicoRepository : IServicoRepository
  {
    private readonly DataContext _context;

    public ServicoRepository(DataContext context) 
    {
      _context = context;
    }

    public void Create(Servico e)
    {
      _context.Servicos.Add(e);
      _context.SaveChanges();
    }

    public void Delete(Servico e)
    {
      _context.Entry(e).State = EntityState.Deleted;
      _context.SaveChanges();
    }

    public List<Servico> Read()
    {
      return _context.Servicos.ToList(); // using System.Linq;
    }

    public List<Servico> Read(Status status)
    {
      // SELECT * FROM Servicos WHERE Status == @status
      return _context.Servicos.Where(e => e.Status == status).ToList();
    }

    public List<Servico> Read(string usuario, Status status)
    {
      return _context.Servicos
        .Where(e => e.Usuario == usuario && e.Status == status)
        .ToList();
    }

    public List<Servico> Read(string usuario)
    {
      // SELECT * FROM Servicos WHERE Usuario == @usuario order by status
      return _context.Servicos
        .Where(e => e.Usuario == usuario)
        .OrderBy(e => e.Status)
        .ToList();
    }

    public Servico Read(Guid id)
    {
      return _context.Servicos.Find(id);
      // return _context.Servicos.Find(id, "");
      // return _context.Servicos.SingleOrDefault(e => e.Id == id && e.Usuario ==  "");
    }

    public void Update(Servico e)
    {
      _context.Entry(e).State = EntityState.Modified;
      _context.SaveChanges();
    }
  }
}