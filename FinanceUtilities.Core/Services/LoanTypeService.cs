using FinanceUtilities.Data;
using System.Collections.Generic;
using System.Linq;
using System;
using FinanceUtilities.Domain;

namespace FinanceUtilities.Core
{
    public class LoanTypeService : ServiceBase, IEntityService<LoanType, LoanType>
    {
        public LoanTypeService(IFinanceContext context) : base(context)
        {
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public LoanType Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<LoanType> GetAll()
        {
            return _context.LoanTypes.ToList();
        }

        public bool Save(LoanType entity, out string id)
        {
            throw new NotImplementedException();
        }
    }
}
