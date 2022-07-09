using api1.modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api1.Data
{
    public class filmecontext : DbContext 
    {
        public filmecontext(DbContextOptions<filmecontext> opt) : base(opt)
        {
            
        }
        public DbSet<Filme> filmes { get; set; }
    }
}
