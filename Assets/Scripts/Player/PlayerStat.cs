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

public struct PlayerStat
{
    private int current_;
    private int min_;
    private int max_;

    //실제 수치(float형)
    private float value_;
    public float currentValue_ { get; private set; }

    public int current
    {
        get { return current_; }
        set 
        { 
            current_ = Mathf.Clamp(value, min_, max_);
            currentValue_ = value_ * current_;
        }
    }
    public int min
    {
        get { return min_; }
        set { if (min_ < 0) min_ = 0; }
    }
    public int max
    {
        get { return max_; }
        set { if (max_ > 0) max_ = 10; }
    }


    public void Initialize(int _current, int _min, int _max, float _value)
    {
        min_ = _min;
        max_ = _max;
        value_ = _value;
        current_ = _current;
        currentValue_ = _value * _current;

        Check();
    }

    public void Check()
    {
        min = min_;
        max = max_;
        current = current_;
    }
}

public class PlayerStatData
{
    public PlayerStat speed;        //Enum: 1
    public PlayerStat weight;       //Enum: 2
    public PlayerStat hp;           //Enum: 3
    public PlayerStat mp;           //Enum: 4


    public PlayerStatData(StatScriptableObject _so)
    {
        Initialize(_so);
    }

    public void Initialize(StatScriptableObject _so)
    {
        speed.Initialize(_so.startSpeed, DefineClass.PlayerStat_MinSpeed, _so.maxSpeed, DefineClass.PlayerStat_SpeedValue);
        weight.Initialize(_so.weight, 1, 20, DefineClass.PlayerStat_WeightValue);
        hp.Initialize(_so.maxHP, DefineClass.PlayerStat_MinHP, _so.maxHP, 0.0f);
        mp.Initialize(0, DefineClass.PlayerStat_MinMP, _so.maxMP, 0.0f);
    }
}