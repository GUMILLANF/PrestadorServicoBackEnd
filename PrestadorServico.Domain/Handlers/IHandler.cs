using PrestadorServico.Domain.Commands;

namespace PrestadorServico.Domain.Handlers
{
  public interface IHandler<T> where T : ICommand
  {
    ICommandResult Handle(T command);
  }
}