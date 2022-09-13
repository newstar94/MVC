using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoDataAccess.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //Foreign Key
        public int StudentId { get; set; }
        //Navigation
        public virtual ICollection<Student> Students { get; set; } //1 class nhiều Student
    }
}