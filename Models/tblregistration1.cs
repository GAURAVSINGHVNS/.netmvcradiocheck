using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace mvcdrc.Models
{
    public class tblregistration1
    {
        [Key]
        public int rid { get; set; }
        public string rname { get; set; }
        public string remail { get; set; }
        public string rpassword { get; set; }
        public int rdepartment { get; set; }
        public int rgender { get; set; }
        public string rhobbies { get; set; }

        public List<tbldepartment> lstdept { get; set; }
        public List<tblgender> lstgender { get; set; }
        public List<tblhobbyy1> lsthobby1 { get; set; }



    }
}