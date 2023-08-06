using System;
using System.Collections.Generic;
using Data;


public class InputStorage : IInputStorage
{
    private Equation _item;
    public event Action OnItemAdded;

    public InputStorage()
    {
    }
    
    public void Set(Equation parts)
    {
        _item = parts;
        OnItemAdded?.Invoke();
    }
    
    public Equation Get()
    {
        return _item;
    }
}
