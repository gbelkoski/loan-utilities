using FinanceUtilities.Data;
using System.Linq;
using System;
using System.Collections.Generic;
using FinanceUtilities.Core.Model;
using FinanceUtilities.Domain;

namespace FinanceUtilities.Core
{
    public class ExpenseTypeService : ServiceBase, IEntityService<IdName, ExpenseType>
    {
        public ExpenseTypeService(IFinanceContext context) : base(context)
        {
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ExpenseType Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(ExpenseType entity, out string id)
        {
            throw new NotImplementedException();
        }


        public List<IdName> GetAll()
        {
            return _context.ExpenseTypes.Select(e => new IdName { Id = e.Id, Name = e.Name }).ToList();
        }
    }
}
