using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Test.Models
{
    public class MyApplicationDbContext : DbContext
    {
        public MyApplicationDbContext(DbContextOptions<MyApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}