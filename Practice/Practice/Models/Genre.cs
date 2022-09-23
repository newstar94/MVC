using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practice.Models
{
    public class Genre
    {
        public long GenreId { get; set; }

        [Required(ErrorMessage ="Bạn chưa nhập tên thể loại phim")]
        [Display(Name ="Thể loại")]
        public string GenreName { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}