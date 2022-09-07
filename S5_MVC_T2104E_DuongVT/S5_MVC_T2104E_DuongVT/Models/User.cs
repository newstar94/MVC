using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S5_MVC_T2104E_DuongVT.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        public string Re_Password { get; set; }
        public string Email { get; set; }

    }
}