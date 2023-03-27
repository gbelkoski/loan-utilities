using FinanceUtilities.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceUtilities.Core
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAll();
    }
}
