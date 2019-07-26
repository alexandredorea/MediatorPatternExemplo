using MediatorPatternExemple.Dominio.Cliente.Comandos;
using MediatorPatternExemple.Infraestrutura;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MediatorPatternExemple.Controllers
{
    /// <summary>
    /// A ClienteController é a classe controladora (controller) da aplicação, ou seja, onde receber as requisições 
    /// da aplicação e fornecer as respostas para cada requisição.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly IMediator mediador;
        private readonly IRepositorioCliente repositorioCliente;

        public ClienteController(IMediator mediador, IRepositorioCliente repositorioCliente)
        {
            this.mediador = mediador;
            this.repositorioCliente = repositorioCliente;
        }

        // GET api/cliente
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await repositorioCliente.Selecionar();
            return Ok(result);
        }

        // GET api/cliente/{guid}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await repositorioCliente.Selecionar(id);
            return Ok(result);
        }

        // POST api/cliente
        [HttpPost]
        public async Task<IActionResult> Post(ComandoCriarCliente comando)
        {
            var response = await mediador.Send(comando);
            return Ok(response);
        }

        // PUT api/cliente
        [HttpPut]
        public async Task<IActionResult> Put(ComandoAtualizarCliente comando)
        {
            var response = await mediador.Send(comando);
            return Ok(response);
        }

        // DELETE api/cliente
        [HttpDelete]
        public async Task<IActionResult> Delete(ComandoExcluirCliente comando)
        {
            var result = await mediador.Send(comando);
            return Ok(result);
        }
    }
}