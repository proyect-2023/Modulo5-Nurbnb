using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nurbnb.Pagos.Domain.Model.CatalogoDevolucion;
using Nurbnb.Pagos.Domain.Model.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Infrastructure.EF.Config
{
    internal class CatalogoDevolucionConfig : IEntityTypeConfiguration<CatalogoDevolucion>
    {
        public void Configure(EntityTypeBuilder<CatalogoDevolucion> builder)
        {
            builder.ToTable("catalogoDevolucion");
            builder.HasKey(x => x.Id);


            builder.Property(x => x.Id)
                .HasColumnName("catalogoDevolucionId");

            var descripcionConverter = new ValueConverter<CatalogoDevolucionDescripcion, string>(
                descripcionValue => descripcionValue.Value,
                descripcion => new CatalogoDevolucionDescripcion(descripcion)
            );

            builder.Property(x => x.Descripcion)
                .HasConversion(descripcionConverter)
                .HasColumnName("descripcion");

            var diaConverter = new ValueConverter<CatalogoDevolucionDias, int>(
             diaValue => (int)diaValue.Value,
             dia => new CatalogoDevolucionDias(dia)
           );

            builder.Property(x => x.NroDias)
                .HasConversion(diaConverter)
                .HasColumnName("nroDias");

            var porcentajeConverter = new ValueConverter<CatalogoDevolucionPorcentaje, int>(
                porcentajeValue => porcentajeValue.Value,
                porcentaje => new CatalogoDevolucionPorcentaje(porcentaje)
            );

            builder.Property(x => x.PorcentajeDescuento)
                .HasConversion(porcentajeConverter)
                .HasColumnName("porcentajeDescuento");

      

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
