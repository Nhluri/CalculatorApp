using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CalculatorApp.Models;

namespace CalculatorApp.Data
{
    public class CalculatorAppContext : DbContext
    {
        public CalculatorAppContext (DbContextOptions<CalculatorAppContext> options)
            : base(options)
        {
        }

        public DbSet<CalculatorApp.Models.Calculator> Calculator { get; set; } = default!;
    }
}
