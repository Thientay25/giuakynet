using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class MyDBContext : DbContext
    {
        public DbSet<Loai> Loais { get; set; }
        public DbSet<TinTuc> TinTucs { get; set; }
        public MyDBContext(DbContextOptions<MyDBContext>
       options) : base(options)
        {
        }
    }
}
