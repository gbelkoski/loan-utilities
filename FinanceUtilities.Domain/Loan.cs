using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceUtilities.Domain
{
    public class LoanProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LoanTypeId { get; set; }
        public virtual LoanType LoanType { get; set; }
        public int BankId { get; set; }
        public virtual Bank Bank { get; set; }
        public string Link { get; set; }

        //criteria
        public int MinDuration { get; set; }
        public int MaxDuration { get; set; }
        public decimal MinimumAmount { get; set; }
        public decimal MaximumAmount { get; set; }
        public string CurrencyCode { get; set; }
        public Currency Currency { get; set; }
        public decimal ParticipationPercentage { get; set; }

        //scraping data
        [Column(TypeName = "ntext")]
        [MaxLength]
        public string Markup { get; set; }
        public DateTime? MarkupDate { get; set; }
        [Column(TypeName = "ntext")]
        [MaxLength]
        public string NewMarkup { get; set; }
        public DateTime? NewMarkupDate { get; set; }
        public bool HasMarkupChanges { get; set; }
        public bool IsDeleted { get; set; }

        public virtual List<InterestPeriod> InterestPeriods { get; set; } = new List<InterestPeriod>();
        public virtual List<LoanProductExpenseType> LoanProductExpenses { get; set; } = new List<LoanProductExpenseType>();
    }
}
