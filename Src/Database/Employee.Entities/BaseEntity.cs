using System.ComponentModel.DataAnnotations;

namespace Employee.Entities
{
    public class BaseEntity
    {
        protected BaseEntity() : base()
        {
            InsertDateTime = DateTime.Now;
            IsActive = true;
        }

        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [Required]

        public DateTime InsertDateTime { get; set; }

        public DateTime? DeleteDateTime { get; set; }
    }
}
