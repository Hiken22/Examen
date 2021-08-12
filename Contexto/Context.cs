using Exam.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Contexto
{
    public class Context : DbContext
    {
        public Context(DbContextOptions opts) : base(opts)
        {
        }
        public DbSet<Productos> productos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
