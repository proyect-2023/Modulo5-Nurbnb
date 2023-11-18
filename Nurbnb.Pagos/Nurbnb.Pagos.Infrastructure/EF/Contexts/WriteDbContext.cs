using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Nurbnb.Pagos.Domain.Model.CatalogoDevolucion;
using Nurbnb.Pagos.Domain.Model.Catalogos;
using Nurbnb.Pagos.Domain.Model.Devoluciones;
using Nurbnb.Pagos.Domain.Model.MedioPagos;
using Nurbnb.Pagos.Domain.Model.Pagos;
using Nurbnb.Pagos.Infrastructure.EF.Config;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Infrastructure.EF.Contexts
{
    internal class WriteDbContext:DbContext
    {
        public virtual DbSet<Catalogo> Catalogo { set; get; }
        public virtual DbSet<Pago> Pago { set; get; }
        public virtual DbSet<DetallePago> DetallePago { set; get; }
        public virtual DbSet<CatalogoDevolucion> CatalogoDevolucion { set; get; }
        public virtual DbSet<Devolucion> Devolucion { set; get; }
        public virtual DbSet<MedioPago> MedioPago { set; get; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var catalogoConfig = new CatalogoConfig();
            modelBuilder.ApplyConfiguration(catalogoConfig);

            var pagoConfig = new PagoConfig();
            modelBuilder.ApplyConfiguration<Pago>(pagoConfig);
            modelBuilder.ApplyConfiguration<DetallePago>(pagoConfig);

            var catalogoDevolucionConfig = new CatalogoDevolucionConfig();
            modelBuilder.ApplyConfiguration<CatalogoDevolucion>(catalogoDevolucionConfig);

            var devolucionConfig = new DevolucionConfig();
            modelBuilder.ApplyConfiguration<Devolucion>(devolucionConfig);

            var medioConfig = new MedioPagoConfig();
            modelBuilder.ApplyConfiguration<MedioPago>(medioConfig);

            modelBuilder.Ignore<DomainEvent>();
            
        }
    }
}
