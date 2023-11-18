using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nurbnb.Pagos.Domain.Model.Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Infrastructure.EF.Config
{
    internal class PagoConfig : IEntityTypeConfiguration<Pago>,
        IEntityTypeConfiguration<DetallePago>
    {
        public void Configure(EntityTypeBuilder<DetallePago> builder)
        {
            builder.ToTable("detallePago");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("detallePagoId");

            builder.Property(x => x.CatalogoId)
                .HasColumnName("catalogoId");

            builder.Property(x => x.Porcentaje)
             .HasColumnName("porcentaje");

            var importeConverter = new ValueConverter<PagoImporte, decimal>(
                importeValue => importeValue.Value,
                importe => new PagoImporte(importe)
            );

            builder.Property(x => x.Importe)
                .HasColumnName("importe")
                .HasConversion(importeConverter);



            builder.Property(x => x.Total)
                .HasColumnName("total");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
        public void Configure(EntityTypeBuilder<Pago> builder)
        {
            builder.ToTable("pago");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("pagoId");

            builder.Property(x => x.FechaRegistro)
                .HasColumnName("fechaRegistro");

            builder.Property(x => x.FechaCancelacion)
                .HasColumnName("fechaCancelacion");

            var tipoConverter = new ValueConverter<TipoPago, int>(
                tipoEnumValue => (int)tipoEnumValue,
                tipo => (TipoPago)Enum.Parse(typeof(TipoPago), tipo.ToString())
            );

            builder.Property(x => x.TipoPago)
                 .HasConversion(tipoConverter)
                 .HasColumnName("tipo");

            builder.Property(x => x.OperacionId)
                .HasColumnName("operacionId");

            builder.Property(x => x.CostoTotalRenta)
               .HasColumnName("costoTotalRenta");

            var estadoConverter = new ValueConverter<EstadoPago, string>(
                estadoEnumValue => estadoEnumValue.ToString(),
                estado => (EstadoPago)Enum.Parse(typeof(EstadoPago), estado)
            );

            builder.Property(x => x.Estado)
                 .HasConversion(estadoConverter)
                 .HasColumnName("estado")
                 .HasMaxLength(20)
                 .IsRequired();

            builder.Property(x => x.CuentaOrigen)
             .HasColumnName("cuentaOrigen");

            builder.Property(x => x.BcoOrigen)
             .HasColumnName("bcoOrigen");

            builder.HasMany(typeof(DetallePago), "_detalle");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
            builder.Ignore(x => x.Detalle);
        }
    }
}
