using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace S5_MVC_T2104E_DuongVT.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Bạn chưa nhập Tên")]
        [Display(Name ="Tên")]
        [MinLength(7,ErrorMessage ="Tên phải lớn hơn 6 ký tự")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu")]
        [Display(Name = "Mật khẩu")]
        [MinLength(5,ErrorMessage ="Mật khẩu phải chứa ít nhất 5 ký tự")]
        [ScaffoldColumn(false)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập lại mật khẩu")]
        [Display(Name = "Nhập lại mật khẩu")]
        [Compare("Password",ErrorMessage ="Mật khẩu không khớp")]
        [ScaffoldColumn(false)]
        [DataType(DataType.Password)]
        public string Re_Password { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",ErrorMessage ="Định dạng email không đúng")]
        public string Email { get; set; }

    }
}