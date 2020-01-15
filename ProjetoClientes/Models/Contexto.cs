using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoClientes.Models
{
    public class Contexto : DbContext
    {
        public DbSet <Clientes> Cliente { get; set;}

        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes) { }
    }
}
