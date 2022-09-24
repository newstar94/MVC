using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WAD_DuongVT_Final.Models
{
    public class Data   : DbContext
    {
        public Data() : base("name=Conn")
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}