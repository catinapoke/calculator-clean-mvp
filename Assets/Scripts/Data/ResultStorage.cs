using System;
using System.Collections.Generic;
using Data;


public class ResultStorage : IResultStorage
{
    private List<Result> _items;
    public event Action OnItemAdded;

    public ResultStorage()
    {
        _items = new List<Result>();
    }

    public void InitIfEmpty(IEnumerable<Result> results)
    {
        if (_items.Count == 0)
        {
            foreach (var item in results)
            {
                _items.Add(item);
            }
        }
    }

    public void AddResult(Result item)
    {
        _items.Add(item);
        OnItemAdded?.Invoke();
    }

    public IEnumerable<Result> GetHistory()
    {
        return _items;
    }
}
