using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EStat
{
    SPD = 0,
    WEIGHT = 1,
    HP = 2,
    MP = 3
}

public class PlayerStatData
{
    public int speed;
    public int weight;
    public int hp;
    public int mp;


    public PlayerStatData(int _speed, int _weight, int _hp, int _mp)
    {
        speed = _speed;
        weight = _weight;
        hp = _hp;
        mp = _mp;
    }
}