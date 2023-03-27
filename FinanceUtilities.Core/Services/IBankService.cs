using FinanceUtilities.Domain;
using System.Collections.Generic;

namespace FinanceUtilities.Core
{
    public interface IBankService
    {
        List<Bank> GetAll();
        Bank Get(int id);
        bool Save(Bank bank);
        bool Delete(int bankId);
    }
}
