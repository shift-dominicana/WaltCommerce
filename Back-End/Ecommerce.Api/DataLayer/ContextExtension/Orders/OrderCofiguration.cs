using Common.Enums;
using Common.Models.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ContextExtension.Orders
{
    public class OrderCofiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.Id).IsRequired().UseIdentityColumn().UseSerialColumn();
            builder.Property(x => x.isPickup).HasDefaultValue(false);
            builder.Property(x => x.PayMode).HasDefaultValue(PayModeEnum.CASH);
            builder.HasOne(x => x.User).WithOne().HasForeignKey<Order>(x => x.User.Id);
            builder.HasMany(x => x.OrderDetails);
        }
    }
}
