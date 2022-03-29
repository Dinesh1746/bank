using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace bank.Models
{
    public partial class Transactions
    {
        [Key]
        public int Transactionno { get; set; }
        public int Accountno { get; set; }
        public int Benaccountno { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public string Remarks { get; set; }

        public virtual Account AccountnoNavigation { get; set; }
        public virtual Benificiary BenaccountnoNavigation { get; set; }
    }
}
