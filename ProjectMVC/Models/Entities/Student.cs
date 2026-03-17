using System.ComponentModel.DataAnnotations;

namespace ProjectMVC.Models.Entities
{
    public class Student
    {
        [Key]
        [Required(ErrorMessage = "Ma sinh vien la bat buoc.")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Ma sinh vien phai tu 3 den 10 ky tu.")]
        [Display(Name = "Ma sinh vien")]
        public string StudentCode { get; set; } = default!;

        [Required(ErrorMessage = "Ho ten sinh vien la bat buoc.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Ho ten phai tu 5 den 100 ky tu.")]
        [Display(Name = "Ho ten")]
        public string FullName { get; set; } = default!;

        [Required(ErrorMessage = "Email la bat buoc.")]
        [StringLength(100, ErrorMessage = "Email toi da 100 ky tu.")]
        [EmailAddress(ErrorMessage = "Email khong dung dinh dang.")]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Tuoi")]
        [Range(16, 100, ErrorMessage = "Tuoi phai nam trong khoang 16 den 100.")]
        public int? Age { get; set; }
    }
}
