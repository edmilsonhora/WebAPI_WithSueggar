using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_With_Swagger_Teste0.Models;
using WebApi_With_Swagger_Teste0.Repository;
using WebApi_With_Swagger_Teste0.Services;

namespace WebApi_With_Swagger_Teste0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        UsuarioRepository _repository;
        public LoginController()
        {
            _repository = new UsuarioRepository();
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public string AutenticateAsync([FromBody] Usuario usuario)
        {
            var u =  _repository.GetBy(usuario.Nome, usuario.Password);
            if (u == null)
                return "Usuário ou Senha Inválidos";

            var token = new TokenService().GenerateToken(u);
            

            return $"Bearer {token}";
            
        }
    }
}
