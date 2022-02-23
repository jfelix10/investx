using Investx.Domain;
using Investx.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Investx.API.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ILogger<ClientesController> _logger;
        private readonly IConfiguration _configuration;
        public ClientesController(ILogger<ClientesController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

















        [HttpPost("inserir-cliente")]
        public ActionResult Inserir([FromForm] Cliente cliente)
        {
            //var classeInvesXDomain = new ClienteXDomain();
            //classeInvesXDomain.Inserir(cliente);
            
            //cliente.Ativo = "cliente ativado com sucesso";



            return Ok();
        } 
        

















        
        
        [HttpGet("recuperar-clientes")]
        public List<Cliente> RecuperarClientes()
        {
            var classeInvesXDomain = new ClienteXDomain();
            var lista = classeInvesXDomain.RecuperarClientes();
            return lista;
        }















        [HttpGet("recuperar-cliente")]
        public Cliente RecuperarCliente(string cpf)
        {
            var classeInvesXDomain = new ClienteXDomain();
            var lista = classeInvesXDomain.RecuperarCliente(cpf);
            return lista;
        }















        [HttpPut]
        public void Atualizar(Cliente investidor, string cpf)
        {
            var classeInvesXDomain = new ClienteXDomain();
            classeInvesXDomain.Atualizar(investidor, cpf);
        }




















        [HttpDelete]
        public void Delete([FromForm] string cpf)
        {
            var clienteDomain = new ClienteXDomain();
            clienteDomain.DeleteCliente(cpf);

        }

    }
}
