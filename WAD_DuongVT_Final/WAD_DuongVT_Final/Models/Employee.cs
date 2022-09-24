using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WAD_DuongVT_Final.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage ="Bạn chưa nhập mã nhân viên")]
        [Display(Name ="Mã nhân viên")]
        [MinLength(4, ErrorMessage = "Mã nhân viên phải chứa 4 ký tự")]
        [MaxLength(4, ErrorMessage = "Mã nhân viên phải chứa 4 ký tự")]
        [Index(IsUnique =true)]
        public string EmployeeID { get; set; }

        [Required(ErrorMessage ="Bạn chưa nhập tên nhân viên")]
        [Display(Name ="Tên nhân viên")]
        [MinLength(2,ErrorMessage ="Tên nhân viên phải chưa tối thiểu 2 ký tự")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage ="Bạn chưa nhập phòng ban")]
        [Display(Name ="Phòng ban")]
        [MinLength(2, ErrorMessage = "Phòng ban phải chứa 2 ký tự")]
        [MaxLength(2, ErrorMessage = "Phòng ban phải chứa 2 ký tự")]
        public string Department { get; set; }

        [Required(ErrorMessage ="Bạn chưa nhập mức lương")]
        [Display(Name ="Mức lương")]
        [Range(1,10000,ErrorMessage ="Mức lương phải >0 và <10.000")]
        public decimal Salary { get; set; }
    }
}