﻿using Common.Models.Sizes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.ContextExtension
{
    public class ProductSizeConfiguration : IEntityTypeConfiguration<ProductSize>
    {
        public void Configure(EntityTypeBuilder<ProductSize> builder)
        {
            //throw new NotImplementedException();
        }
    }
}
