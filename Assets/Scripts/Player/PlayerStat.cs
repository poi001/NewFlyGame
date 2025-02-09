using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat
{
    public int max_int { get; protected set; }
    public int current_int { get; protected set; }
    public float max_float { get; protected set; }
    public float current_float { get; protected set; }

    public PlayerStat(int max, int cur)
    {
        max_int = max;
        current_int = cur;
    }

    public PlayerStat(float max, float cur)
    {
        max_float = max;
        current_float = cur;
    }

    public void AddStat(int add)
    {
        current_int = Mathf.Clamp(current_int + add, 0, max_int);
    }

    public void AddStat(float add)
    {
        current_float = Mathf.Clamp(current_float + add, 0.0f, max_float);
    }

    public void SubStat(int sub)
    {
        current_int = Mathf.Clamp(current_int - sub, 0, max_int);
    }

    public void SubStat(float sub)
    {
        current_float = Mathf.Clamp(current_float - sub, 0.0f, max_float);
    }
}

//public class Speed : PlayerStat
//{
//    public Speed(int max, int cur) : base(max, cur)
//    {

//    }
//}

//public class Weight : PlayerStat
//{
//    public Weight(int max, int cur) : base(max, cur)
//    {

//    }
//}

//public class HP : PlayerStat
//{
//    public HP(int max, int cur) : base(max, cur)
//    {

//    }
//}

//public class MP : PlayerStat
//{
//    public MP(int max, int cur) : base(max, cur)
//    {

//    }
//}