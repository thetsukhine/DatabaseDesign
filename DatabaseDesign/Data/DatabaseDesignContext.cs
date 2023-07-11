using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DatabaseDesign.Models;

namespace DatabaseDesign.Data
{
    public class DatabaseDesignContext : DbContext
    {
        public DatabaseDesignContext (DbContextOptions<DatabaseDesignContext> options)
            : base(options)
        {
        }

        public DbSet<DatabaseDesign.Models.Information> Information { get; set; } = default!;

        public DbSet<DatabaseDesign.Models.HealthDeclaration>? HealthDeclaration { get; set; }
    }
}
