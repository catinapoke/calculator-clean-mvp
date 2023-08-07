using System.Collections.Generic;

namespace Data
{
    public interface IResultStorage
    {
        void InitIfEmpty(IEnumerable<Result> results);
        void AddResult(Result parts);
        IEnumerable<Result> GetHistory() ;
    }
}