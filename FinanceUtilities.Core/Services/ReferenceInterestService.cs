using FinanceUtilities.Core.Model;
using FinanceUtilities.Data;
using System.Linq;
using System;
using System.Collections.Generic;
using FinanceUtilities.Domain;

namespace FinanceUtilities.Core
{
    public class ReferenceInterestService : ServiceBase, IEntityService<IdName, ReferenceInterest>
    {
        public ReferenceInterestService(IFinanceContext context) : base(context)
        {
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ReferenceInterest Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<IdName> GetAll()
        {
            return _context.ReferenceInterests.Select(r => new IdName { Id = r.Id, Description = r.Description }).ToList();
        }

        public bool Save(ReferenceInterest entity, out string id)
        {
            throw new NotImplementedException();
        }
    }
}
