using ManageContacts.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManageContacts.Entity.EntityConfigurations;

public class EmailTypeConfiguration : IEntityTypeConfiguration<EmailType>
{
    public void Configure(EntityTypeBuilder<EmailType> builder)
    {
        builder.HasQueryFilter(x => !x.Deleted);
            
        builder.Property(u => u.CreatedTime)
            .HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
            
        builder.Property(u => u.ModifiedTime)
            .HasConversion(v => v, v => DateTime.SpecifyKind(v.Value, DateTimeKind.Utc));

        builder.HasOne(c => c.Contact)
            .WithMany()
            .HasForeignKey(c => c.ContactId)
            .IsRequired(false);
        
    }
}