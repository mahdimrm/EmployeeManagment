using System.ComponentModel.DataAnnotations;

namespace Employee.Entities
{
    public class Employee : BaseEntity
    {

        [Display(Name = "نام")]
        [Required(ErrorMessage = "  لطفا {0} وارد کنید")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "  لطفا {0} وارد کنید")]
        public string LastName { get; set; }

        [Display(Name = "کد پرسنلی")]
        [Required(ErrorMessage = "  لطفا {0} وارد کنید")]
        public string PersonalCode { get; set; }

        [Display(Name = "تاریخ تولد")]
        [Required(ErrorMessage = "  لطفا {0} وارد کنید")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "نام پدر")]
        [Required(ErrorMessage = "  لطفا {0} وارد کنید")]
        public string FatherName { get; set; }

        [Display(Name = "نوع کارکنان")]
        [Required(ErrorMessage = "  لطفا {0} وارد کنید")]
        public string Type { get; set; }

        [Display(Name = "درجه")]
        [Required(ErrorMessage = "  لطفا {0} وارد کنید")]
        public Guid GradeId { get; set; }

        [Display(Name = "کد ملی")]
        [Required(ErrorMessage = "  لطفا {0} وارد کنید")]
        public string NationalCode { get; set; }

        [Display(Name = "شماره همراه")]
        [Required(ErrorMessage = "  لطفا {0} وارد کنید")]
        public string PhoneNumber { get; set; }

        [Display(Name = "تعداد عائله با احتساب سرپرست")]
        [Required(ErrorMessage = "  لطفا {0} وارد کنید")]
        public int TedadAeleBaEhtesabSarparast { get; set; }

        [Display(Name = "محل صدور شناسنامه")]
        [Required(ErrorMessage = "  لطفا {0} وارد کنید")]
        public string MahaleSodoreShenasname { get; set; }

        [Display(Name = "آدرس")]
        [Required(ErrorMessage = "  لطفا {0} وارد کنید")]
        public string Address { get; set; }

        [Display(Name = "کد پستی ")]
        [Required(ErrorMessage = "  لطفا {0} وارد کنید")]
        public string PostCode { get; set; }

        [Display(Name = "تاریخ استخدام ")]
        [Required(ErrorMessage = "  لطفا {0} وارد کنید")]
        public DateTime EmployedDateTime { get; set; }

        [Display(Name = "وضعیت تاهل")]
        [Required(ErrorMessage = "  لطفا {0} وارد کنید")]
        public bool IsEngage { get; set; }

        //Relations
        public virtual List<Child> Children { get; set; }
        public virtual List<Wife> Wives { get; set; }
        public virtual Grade Grade { get; set; }
    }
}
