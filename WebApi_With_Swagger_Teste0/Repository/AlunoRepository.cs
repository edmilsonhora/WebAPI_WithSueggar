using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_With_Swagger_Teste0.Models;

namespace WebApi_With_Swagger_Teste0.Repository
{
    public class AlunoRepository
    {
        public List<Aluno> GetAll()
        {
            return new List<Aluno>()
            {
                new Aluno(){ Id=1, Nome="Edmilson Hora", Nota="8"},
                new Aluno(){ Id=2, Nome="Elisangela Ferreira", Nota="6"},
                new Aluno(){ Id=3, Nome="Eduarda F. da Hora", Nota="7"},
                new Aluno(){ Id=4, Nome="Luan Ferreira de Sousa da Hora", Nota="8"},
            };
        }

        public Aluno GetBy(int id)
        {
            return GetAll().FirstOrDefault(p => p.Id.Equals(id));
        }
    }
}
