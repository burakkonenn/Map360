using Domain.Entities.Common;
using Domain.Entities.Company;
using Domain.Entities.Task;
using Domain.Entities.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Context
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserDoc>()
            .Property(b => b.User)
            .HasColumnType("jsonb");


            builder.Entity<CompanyDoc>()
            .Property(b => b.Company)
            .HasColumnType("jsonb");
        }

        public DbSet<UserDoc> Users { get; set; }
        public DbSet<CompanyDoc> Companies { get; set; }
        public DbSet<TaskDoc> Tasks { get; set; }
    }
}
