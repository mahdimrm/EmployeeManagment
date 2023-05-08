using System.ComponentModel.DataAnnotations;

namespace Employee.Entities
{
    public class Grade : BaseEntity
    {
        [Display(Name = "درجه")]
        [Required(ErrorMessage = "  لطفا {0} وارد کنید")]
        public string Name { get; set; }
    }
}
