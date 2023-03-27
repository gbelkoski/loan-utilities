using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FinanceUtilities.Core
{
    public interface IEntityService<T,K>
    {
        List<T> GetAll();
        K Get(int id);
        bool Save(K entity, out string id);
        bool Delete(int id);
    }
}
