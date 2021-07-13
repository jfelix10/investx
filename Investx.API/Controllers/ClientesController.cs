using Dapper;
using Investx.Domain;
using Investx.Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


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

        [HttpDelete]
        public void Delete([FromForm] int id)
        {
            var clienteDomain = new ClienteXDomain();
            clienteDomain.DeleteCliente(id);

        }
        [HttpPost]
        public void Inserir([FromForm] Cliente cliente)
        {
            var classeInvesXDomain = new ClienteXDomain();
            classeInvesXDomain.Inserir(cliente);

        }
        [HttpPut]
        public void Atualizar(Cliente investidor, int id)
        {
            var classeInvesXDomain = new ClienteXDomain();
            classeInvesXDomain.Atualizar(investidor,id);
        }

        [HttpGet]
        public Cliente RecuperarCliente(string cpf)
        {
            var classeInvesXDomain = new ClienteXDomain();
            var lista = classeInvesXDomain.RecuperarCliente(cpf);
            return lista;
        }

    }
}
