using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mink.Domain.Models.Entities;

namespace Mink.Data.Configurations
{
    public class MinifiedUriConfiguration : IEntityTypeConfiguration<MinifiedUri>
    {
        public void Configure(EntityTypeBuilder<MinifiedUri> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.OriginUri).IsRequired();
            builder.Property(x => x.MinifiedUriKey).IsRequired();
            builder.Property(x => x.QrImageUri).IsRequired(false);
        }
    }
}