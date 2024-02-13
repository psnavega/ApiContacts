using System;
using ApiContacts.Infra.Map;
using ApiContacts.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiContacts.Infra
{
    public class DatabaseContext: DbContext
	{
		public IConfiguration _configuration;

		public DatabaseContext(DbContextOptions<DatabaseContext> options, IConfiguration configuration) : base(options)
		{
            _configuration = configuration;
		}

        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = _configuration.GetConnectionString("DatabaseString");

                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException("The connection string is not configured");
                }

                optionsBuilder.UseSqlServer(connectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContatoMap());
            base.OnModelCreating(modelBuilder);
        }

        protected void EnsureDatabaseCreated()
        {
            Database.EnsureCreated();
        }

        internal Usuario Find(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}

