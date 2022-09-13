using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WAD_T2104E_DuongVT.Models
{
    public class DataDbContext : DbContext
    {
        //public DataDbContext() : base("name=Conn")
        //{
        //}
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}