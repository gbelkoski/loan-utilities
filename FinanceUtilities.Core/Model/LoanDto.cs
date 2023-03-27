using System;
using System.Collections.Generic;

namespace FinanceUtilities.Core.Model
{
    public class LoanDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BankName { get; set; }
        public string LoanType { get; set; }
        public string LastChange { get; set; }
        public bool HasChanges { get; set; }
        public DateTime? NewMarkupDate { get; internal set; }
    }
}
