using Project.Youtube.Models.Enums;
using Project.Youtube.Models.Interfaces;

namespace Project.Youtube.Models.Entities
{
    public abstract class BaseEntity : IEntity
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus Status { get; set; }
        public BaseEntity()
        {
            Status = DataStatus.Inserted;
            CreatedDate = DateTime.Now;
        }
    }
}
