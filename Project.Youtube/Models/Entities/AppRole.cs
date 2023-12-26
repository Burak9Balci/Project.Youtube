using Microsoft.AspNetCore.Identity;
using Project.Youtube.Models.Enums;
using Project.Youtube.Models.Interfaces;

namespace Project.Youtube.Models.Entities
{
    public class AppRole : IdentityRole<int>, IEntity
    {
        public AppRole()
        {
            CreatedDate = DateTime.Now;
            Status = DataStatus.Inserted;
        }
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus Status { get; set; }

        //RS

        public virtual List<AppUserRole> UserRoles { get; set; }
    }
}
