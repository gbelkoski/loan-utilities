using System.Collections.Generic;
using System.Linq;

namespace FinanceUtilities.Core.Model
{
    public class ResponseDto<T>
    {
        public List<string> Errors { get; set; }
        public bool HasErrors { get { return Errors.Any(); } }
        public T Data { get; set; }
    }
}
