using DAO.Mappings;
using DTO;
using DTO.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class SSContext : DbContext
    {
        public SSContext():base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ESTACIONAMENTODB_ef62ac46ce0642bdb42d9f59ded55587;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {

        }

        public DbSet<ClienteDTO> Clientes { get; set; }
        public DbSet<ProdutoDTO> Produtos { get; set; }
        public DbSet<CategoriaDTO> Categorias{ get; set; }
        public DbSet<FornecedorDTO> Fornecedores { get; set; }
        public DbSet<UsuarioDTO> Usuarios { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Properties()
                        .Where(c => c.PropertyType == typeof(string))
                        .Configure(c => c.IsRequired().IsUnicode(false));

            base.OnModelCreating(modelBuilder);
        }
    }
}
