using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class D
{
    public static List<int> scoreList = new List<int>();
    public static bool Persent(float persent)
    {
        return Random.Range(0, 99) < persent;
    }
}
