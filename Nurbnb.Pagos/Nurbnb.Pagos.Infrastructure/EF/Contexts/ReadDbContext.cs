using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nurbnb.Pagos.Domain.Model.Catalogos;
using Nurbnb.Pagos.Infrastructure.EF.ReadModel;

namespace Nurbnb.Pagos.Infrastructure.EF.Contexts
{
    internal class ReadDbContext : DbContext
    {
        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<CatalogoReadModel> Catalogo { get; set; }
        public virtual DbSet<DetallePagoReadModel> DetallePago { get; set; }
        public virtual DbSet<PagoReadModel> Pago { get; set; }
        public virtual DbSet<DevolucionReadModel> Devolucion { get; set; }
        public virtual DbSet<CatalogoDevolucionReadModel> CatalogoDevolucion { get; set; }
        public virtual DbSet<MedioPagoReadModel> MedioPago { get; set; }
    }
}
