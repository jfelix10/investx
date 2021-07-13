using Investx.Domain;
using Investx.Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Investx.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarteiraController : ControllerBase
    {
        private readonly ILogger<CarteiraController> _logger;
        private readonly IConfiguration _configuration;
        public CarteiraController(ILogger<CarteiraController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        
        [HttpDelete]
        public void Delete([FromForm] int id) { }
        [HttpPost]
        public void Inserir([FromForm] Carteira carteira) { }
        [HttpPut]
        public void Atualizar(Carteira carteira, int id) { }
        [HttpGet]
        public List<Carteira> RecuperarCarteiras(){
            List<Carteira> carteira = null;
            return carteira;
        }

        }
}
