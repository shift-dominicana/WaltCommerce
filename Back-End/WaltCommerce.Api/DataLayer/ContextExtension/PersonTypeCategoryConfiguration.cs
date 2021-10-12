using Common.Models.PersonTypeCategories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.ContextExtension
{
    public class PersonTypeCategoryConfiguration : IEntityTypeConfiguration<PersonTypeCategory>
    {
        public void Configure(EntityTypeBuilder<PersonTypeCategory> builder)
        {

            //builder.Property(x => x.Email).IsRequired().HasMaxLength(40);

        }
    }
}
