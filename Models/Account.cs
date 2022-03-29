using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace bank.Models
{
    public partial class Account
    {
       
        public Account()
        {
            Benificiary = new HashSet<Benificiary>();
            Transactions = new HashSet<Transactions>();
        }

        public int Rid { get; set; }
        public int Accountno { get; set; }
        public int Balance { get; set; }
        public string Name { get; set; }

        public virtual Register R { get; set; }
        public virtual ICollection<Benificiary> Benificiary { get; set; }
        public virtual ICollection<Transactions> Transactions { get; set; }
    }
}
