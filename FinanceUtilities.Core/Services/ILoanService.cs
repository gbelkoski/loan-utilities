using FinanceUtilities.Core.Model;
using FinanceUtilities.Data;
using System.Collections;
using System.Collections.Generic;

namespace FinanceUtilities.Core
{
    public interface ILoanService : IEntityService<LoanDto, LoanDetailsDto>
    {
        IEnumerable<LoanDto> Get(int? bankId, string loanId, bool showOnlyMarkupChanges);
        LoanMarkupDto GetMarkup(int loanId);
    }
}
