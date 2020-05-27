using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PrestadorServico.Domain.Commands;
using PrestadorServico.Domain.Entities;
using PrestadorServico.Domain.Handlers;
using PrestadorServico.Domain.Repositories;

// localhost:5000/v1/servico
namespace PrestadorServico.Api.Controllers
{
  [ApiController]
  [Route("v1/servico")]
  public class ServicoController : ControllerBase
  {
    [HttpGet]
    [Route("")]
    public List<Servico> Get([FromServices]IServicoRepository repository)
    {
      return repository.Read();
    }

    [HttpPost]
    [Route("")]
    public ActionResult Post(CreateServicoCommand cmd, [FromServices]ServicoHandler handler)
    {
       return Ok(handler.Handle(cmd));
    }
  }
}