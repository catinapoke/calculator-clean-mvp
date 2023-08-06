using System.Collections.Generic;

namespace Data
{
    public interface IResultStorage
    {
        void AddResult(Result parts);
        IEnumerable<Result> GetHistory() ;
    }
}