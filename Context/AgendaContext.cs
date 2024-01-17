using Microsoft.EntityFrameworkCore;
using Projeto_MVC_DIO.Models;

namespace Projeto_MVC_DIO.Context;

public class AgendaContext : DbContext
{
    public AgendaContext(DbContextOptions<AgendaContext>options) : base(options)
    { 
    
    }

    public DbSet<Contato> Contatos { get; set; }

    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }
}
