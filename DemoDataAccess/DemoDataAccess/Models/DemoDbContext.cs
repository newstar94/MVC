using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DemoDataAccess.Models
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext() :base("name=Conn")
        {
        }
        public DbSet<Class> ClassList { get; set; }
        public DbSet<Student> StudentList { get; set; }
    }
}