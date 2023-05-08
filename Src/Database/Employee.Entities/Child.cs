using System.ComponentModel.DataAnnotations;

namespace Employee.Entities
{
    public class Child : BaseEntity
    {
        [Display(Name = "فرزند")]
        [Required]
        public Guid EmployeeId { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "  لطفا {0} وارد کنید")]
        public string FirstName { get; set; }


        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "  لطفا {0} وارد کنید")]
        public string LastName { get; set; }

        [Display(Name = "کد ملی")]
        [Required(ErrorMessage = "  لطفا {0} وارد کنید")]
        public string NationalCode { get; set; }

        [Display(Name = "تاریخ تولد")]
        [Required(ErrorMessage = "  لطفا {0} وارد کنید")]
        public string BirthDate { get; set; }

        [Display(Name = "محله صدور شناسنامه")]
        [Required(ErrorMessage = "  لطفا {0} وارد کنید")]
        public string MahaleSodoreShenasname { get; set; }


        //Relations 
        public virtual Employee Employee { get; set; }
    }
}
