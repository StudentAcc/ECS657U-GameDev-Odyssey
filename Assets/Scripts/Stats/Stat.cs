using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Stat
{
    // Serialized field for stats
    [SerializeField]
    public int baseValue;

    public int GetValue ()
    {
        return baseValue;
    }
}
