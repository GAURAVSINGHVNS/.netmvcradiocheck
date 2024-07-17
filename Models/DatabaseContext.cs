using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace mvcdrc.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("xyz")
        {

        }
        public DbSet<tbldepartment> tbldepartments { get; set; }
        public DbSet<tblgender> tblgenders { get; set; }
        public DbSet<tblhobby> tblhobbies { get; set; }
        public DbSet<tblregistration> tblregistrations { get; set; }

    }
}