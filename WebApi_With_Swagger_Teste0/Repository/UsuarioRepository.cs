using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_With_Swagger_Teste0.Models;

namespace WebApi_With_Swagger_Teste0.Repository
{
    public class UsuarioRepository
    {
        public List<Usuario> GetAll()
        {
            return new List<Usuario>()
            {
                new Usuario (){ Id =1, Nome="carlos.almeida", Password="senha", Role="professor"},
                new Usuario (){ Id =1, Nome="edmilson.hora", Password="senha", Role="aluno"},
            };
        }

        public Usuario GetBy(string nome, string senha)
        {
            return GetAll().FirstOrDefault(p => p.Nome.Equals(nome) && p.Password.Equals(senha));
        }
    }
}
