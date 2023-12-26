using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Youtube.Models.Entities;

namespace Project.Youtube.Models.Configurations
{
    public class AppRoleConfiguration : BaseConfiguration<AppRole>
    {
        public override void Configure(EntityTypeBuilder<AppRole> builder)
        {
            base.Configure(builder);
            builder.Ignore(x => x.ID);
        }
    }
}
