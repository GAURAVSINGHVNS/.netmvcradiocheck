using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace mvcdrc.Models
{
    public class tbldepartment
    {
        [Key]
        public int did { get; set; }
        public string dname { get; set; }
    }
}