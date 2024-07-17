using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcdrc.Models
{
    public class tblhobby
    {
        [Key]
        public int hid { get; set; }
        public string hname { get; set; }
    }
}