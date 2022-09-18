using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WAD_T2104E_DuongVT.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        [StringLength(32, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:n}")]
        public decimal Price { get; set; }
        [Required]
        [Range(1, 100)]
        public int Quantity { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}