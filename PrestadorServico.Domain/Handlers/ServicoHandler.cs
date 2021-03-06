using PrestadorServico.Domain.Commands;
using PrestadorServico.Domain.Entities;
using PrestadorServico.Domain.Repositories;

namespace PrestadorServico.Domain.Handlers
{
  public class ServicoHandler :
    IHandler<CreateServicoCommand>,
    IHandler<UpdateTituloServicoCommand>
  {

    private readonly IServicoRepository _repository;

    // D = Injeção de Dependências.
    public ServicoHandler(IServicoRepository repository)
    {
      _repository = repository;
    }

    public ICommandResult Handle(CreateServicoCommand command)
    {
      // fail-first principle
      if(!command.Validate())
        return new CommandResult("error", "Falha ao criar um serviço.", command);

      var servico = new Servico(command.Usuario, command.Titulo, command.Descricao);

      _repository.Create(servico);

      return new CommandResult("success", "Serviço criado com sucesso.", servico);
    }

    public ICommandResult Handle(UpdateTituloServicoCommand command)
    {
      if(!command.Validate())
        return new CommandResult("error", "Falaha ao atualizar o título do serviço.", command);

      var servico = _repository.Read(command.Id);

      // servico.Titulo = command.Titulo;     // ERRADO
      servico.AlterarTitulo(command.Titulo);  // CORRETO

      _repository.Update(servico);

      return new CommandResult("success", "Título do serviço alterado com sucesso.", servico);
    }
  }
}