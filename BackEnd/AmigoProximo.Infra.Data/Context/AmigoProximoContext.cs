using AmigoProximo.Domain.Entities;
using AmigoProximo.Infra.Data.EntityConfig;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigoProximo.Infra.Data.Context
{
    public class AmigoProximoContext : DbContext
    {
        public AmigoProximoContext()
            : base("AWSDB")
        {
            Database.SetInitializer<AmigoProximoContext>(null);
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Amigo> Amigos { get; set; }

        public DbSet<AmigoProximo.Domain.Entities.AmigoProximo> AmigoProximos { get; set; }

        public DbSet<CalculoHistorico> CalculoHistoricos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == "ID")
                .Configure(p => p.IsKey().HasColumnOrder(0));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            modelBuilder.Configurations.Add(new AmigoConfiguration());
            modelBuilder.Configurations.Add(new AmigoProximoConfiguration());
            modelBuilder.Configurations.Add(new CalculoHistoricoConfiguration());
        }

        public override int SaveChanges()
        {

            //return base.SaveChanges();

            try
            {
                return base.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entidade do tipo \"{0}\" no estado \"{1}\" tem os seguintes erros de validação:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Erro: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}
