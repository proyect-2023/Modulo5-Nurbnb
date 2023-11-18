using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nurbnb.Pagos.Domain.Model.Devoluciones;
using Nurbnb.Pagos.Domain.Model.Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Infrastructure.EF.Config
{
    internal class DevolucionConfig : IEntityTypeConfiguration<Devolucion>
    {
        public void Configure(EntityTypeBuilder<Devolucion> builder)
        {
            builder.ToTable("devolucion");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("devolucionId");

            builder.Property(x => x.FechaRegistro)
               .HasColumnName("fechaRegistro");

            builder.Property(x => x.PagoId)
                .HasColumnName("pagoId");

            builder.Property(x => x.CatalogoDevolucionId)
               .HasColumnName("catalogoDevolucionId");


            builder.Property(x => x.PorcentajeDevolucion)
                .HasColumnName("porcentajeDevolucion");

            builder.Property(x => x.ImportePago)
           .HasColumnName("importePago");

            builder.Property(x => x.TotalDevolucion)
             .HasColumnName("totalDevolucion");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
