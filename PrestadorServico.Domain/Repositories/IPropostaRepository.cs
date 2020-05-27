using System;
using System.Collections.Generic;
using PrestadorServico.Domain.Entities;

namespace PrestadorServico.Domain.Repositories
{
  public interface IPropostaRepository
  {
    List<Proposta> Read(Guid servicoId);
    Proposta Read(Guid servicoId, Guid id);
    void Create(Proposta e);
    void Update(Proposta e);
    void Delete(Proposta e);
  }
}

// Command Query Responsibility Segregation (CQRS)