using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Youtube.Models.Entities;

namespace Project.Youtube.Models.Configurations
{
    public class AppUserConfiguration : BaseConfiguration<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
           
            builder.Ignore(x => x.ID);
            builder.HasMany(x => x.UserRoles).WithOne(x => x.User).HasForeignKey(x =>x.UserId).IsRequired();
        }
    }
}
