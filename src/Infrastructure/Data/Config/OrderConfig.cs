using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.Config
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.BuyerId).IsRequired();

            builder.OwnsOne(x => x.ShipToAddress, onb => {
                onb.WithOwner();
                onb.Property(a => a.City).HasMaxLength(100).IsRequired();
                onb.Property(a => a.Street).HasMaxLength(200).IsRequired();
                onb.Property(a => a.State).HasMaxLength(60);
                onb.Property(a => a.ZipCode).HasMaxLength(18).IsRequired();
                onb.Property(a => a.Country).HasMaxLength(90).IsRequired();
            });

            builder.Navigation(x => x.ShipToAddress).IsRequired();
        }
    }
}
