using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practice.Models
{
    public class Movie
    {
        public long MovieId { get; set; }

        [Required(ErrorMessage ="Bạn chưa nhập tên phim")]
        [Display(Name ="Tên phim")]
        public string MovieTitle { get; set; }

        [Required(ErrorMessage ="Bạn chưa nhập ngày phát hành")]
        [Display(Name ="Ngày phát hành")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage ="Bạn chưa nhập thời lượng phim")]
        [Display(Name ="Thời lượng")]
        public int RunningTime { get; set; }
        [Required(ErrorMessage ="Bạn chưa chọn thể loại phim")]
        public long GenreId { get; set; }
        public virtual Genre Genre { get; set; }
    }
}