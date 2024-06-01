using Microsoft.EntityFrameworkCore;
using TrainingApi.Entities;

namespace TrainingApi.Context
{
    // É a classe que vai acessar o banco de dados, ele que vai ser utilizado para chamar a conexão com o banco
    public class AgendaContext : DbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
        {
        }

        // Se alguma entidade não estiver no DbSet, ela não vai ser identificada como tabela
        public DbSet<Contato> Contatos { get; set; }
    }
}
