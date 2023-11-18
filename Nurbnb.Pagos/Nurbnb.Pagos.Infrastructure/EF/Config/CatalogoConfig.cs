using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nurbnb.Pagos.Domain.Model.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Infrastructure.EF.Config
{
    internal class CatalogoConfig : IEntityTypeConfiguration<Catalogo>
    {
        public void Configure(EntityTypeBuilder<Catalogo> builder)
        {
            builder.ToTable("catalogo");
            builder.HasKey(x => x.Id);


            builder.Property(x => x.Id)
                .HasColumnName("catalogoId");

            var descripcionConverter = new ValueConverter<CatalogoDescripcion, string>(
                descripcionValue => descripcionValue.Value,
                descripcion => new CatalogoDescripcion(descripcion)
            );

            builder.Property(x => x.Descripcion)
                .HasConversion(descripcionConverter)
                .HasColumnName("descripcion");

            var porcentajeConverter = new ValueConverter<CatalogoPorcentaje, int>(
                porcentajeValue => porcentajeValue.Value,
                porcentaje => new CatalogoPorcentaje(porcentaje)
            );

            builder.Property(x => x.Porcentaje)
                .HasConversion(porcentajeConverter)
                .HasColumnName("porcentaje");

            var esreservaConverter = new ValueConverter<TipoCatalogo, int>(
             esreservaEnumValue => (int)esreservaEnumValue,
             esreserva => (TipoCatalogo)Enum.Parse(typeof(TipoCatalogo), esreserva.ToString())
            );

            builder.Property(x => x.EsReserva)
                .HasColumnName("esReserva");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
