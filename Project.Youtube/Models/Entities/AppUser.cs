using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Project.Youtube.Models.Enums;
using Project.Youtube.Models.Interfaces;

namespace Project.Youtube.Models.Entities
{
    public class AppUser : IdentityUser<int>, IEntity
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus Status { get; set; }
        public AppUser()
        {
            Status = DataStatus.Inserted;
            CreatedDate = DateTime.Now;
        }
        //Relational Property
        public virtual List<AppUserRole> UserRoles { get; set; }
    }
}
