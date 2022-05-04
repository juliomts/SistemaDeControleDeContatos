using Microsoft.EntityFrameworkCore;
using SistemaDeCadastroDeContatos.Models;

namespace SistemaDeCadastroDeContatos.Data
{
    public class ContatoContext : DbContext
    {
        public ContatoContext(DbContextOptions<ContatoContext> options) : base(options)
        { 
        }
        public DbSet<ContatoModel> Contatos { get ; set; }

    }
}
