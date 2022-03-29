using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace bank.Models
{
    public partial class Custinfo
    {
        [Key]
        public int Cid { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public long Mobile { get; set; }
        public string Email { get; set; }
        public long Aadhar { get; set; }
        public DateTime Dob { get; set; }
        public string Address { get; set; }
        public string Occupation { get; set; }
    }
}
