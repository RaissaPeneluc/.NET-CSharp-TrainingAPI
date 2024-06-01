using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingApi.Entities
{
    // É a entidade, é uma classe trabalhada na API e a ao mesmo tempo é uma tabela no banco de dados
    public class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
    }
}