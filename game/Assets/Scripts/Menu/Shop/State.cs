using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class State 
{
    public int _count;

    public virtual int Count
    {
        get { return _count; }
        set
        {
            if (value <= 0)
            {
                _count = 0;
            }
            else
            {
                _count = value;
            }
        }
    }
}
