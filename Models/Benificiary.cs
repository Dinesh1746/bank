using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace bank.Models
{
    public partial class Benificiary
    {
        public Benificiary()
        {
            Transactions = new HashSet<Transactions>();
        }
        [Key]
        public string Name { get; set; }
        public int Benaccountno { get; set; }
        public int Accountno { get; set; }
        public string Nickname { get; set; }

        public virtual Account AccountnoNavigation { get; set; }
        public virtual ICollection<Transactions> Transactions { get; set; }
    }
}
