using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace bank.Models
{
    public partial class Register
    {
        public Register()
        {
            Account = new HashSet<Account>();
        }
        [Key]
        public int Rid { get; set; }
        public int Accountno { get; set; }
        public string Userid { get; set; }
        public string Password { get; set; }
        public string Transactionpass { get; set; }

        public virtual ICollection<Account> Account { get; set; }
    }
}
