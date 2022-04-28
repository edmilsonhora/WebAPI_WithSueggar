using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_With_Swagger_Teste0.Repository;

namespace WebApi_With_Swagger_Teste0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        AlunoRepository _repository;
        public AlunoController()
        {
            _repository = new AlunoRepository();
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize(Roles ="professor")]
        public IActionResult ObterTodos()
        {
            try
            {
                return Ok(_repository.GetAll());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
                
            }            
        }

        [HttpGet]
        [Route("GetBy/{id}")]
        [Authorize(Roles = "professor,aluno")]
        public IActionResult ObterPor(int id)
        {
            try
            {
                return Ok(_repository.GetBy(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
    }
}
