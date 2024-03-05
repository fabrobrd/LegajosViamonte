using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Legajos.Domain.Mapping
{
    internal class RrhhConfig : IEntityTypeConfiguration<Rrhh>
    {
        public void Configure(EntityTypeBuilder<Rrhh> builder)
        {
            builder.HasNoKey();
        }
    }
}
