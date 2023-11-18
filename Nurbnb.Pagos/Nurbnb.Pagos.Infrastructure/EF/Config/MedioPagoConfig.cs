using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nurbnb.Pagos.Domain.Model.Catalogos;
using Nurbnb.Pagos.Domain.Model.MedioPagos;
using Nurbnb.Pagos.Domain.Model.Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Infrastructure.EF.Config
{
    internal class MedioPagoConfig :
        IEntityTypeConfiguration<MedioPago>
    {
        public void Configure(EntityTypeBuilder<MedioPago> builder)
        {
            builder.ToTable("medioPago");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("medioPagoId");

            builder.Property(x => x.PagoId)
                .HasColumnName("pagoId");


            builder.Property(x => x.CuentaOrigen)
             .HasColumnName("cuentaOrigen");

            builder.Property(x => x.BcoOrigen)
             .HasColumnName("bcoOrigen");

            builder.Property(x => x.Importe)
          .HasColumnName("importe");

            builder.Property(x => x.ComprobanteExterno)
         .HasColumnName("comprobanteExterno");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        
        }
    }
}
