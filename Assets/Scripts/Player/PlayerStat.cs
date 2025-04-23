using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EStatType
{
    SPD = 0,
    WEIGHT = 1,
    HP = 2,
    MP = 3
}

public class PlayerStat
{
    private int current_;
    public int min;
    public int max;
    public int Init { get; private set; }

    //실제 수치(float형)
    public float value_ { get; private set; }
    public float currentValue_ { get; private set; }

    public int current
    {
        get { return current_; }
        set
        {
            current_ = Mathf.Clamp(value, min, max);
            currentValue_ = value_ * current_;
        }
    }

    public PlayerStat(int _current, int _min, int _max, float _value)
    {
        min = _min;
        max = _max;
        value_ = _value;
        current_ = _current;
        Init = _current;
        currentValue_ = _value * _current;

        current = current_;
    }
}

public class PlayerStatData
{
    public PlayerStat speed;        //Enum: 1
    public PlayerStat weight;       //Enum: 2
    public PlayerStat hp;           //Enum: 3
    public PlayerStat mp;           //Enum: 4
    public Dictionary<EStatType, PlayerStat> Data { get; private set; }

    public PlayerStatData(StatScriptableObject _so)
    {
        Initialize(_so);
    }

    public void Initialize(StatScriptableObject _so)
    {
        speed = new PlayerStat
            (_so.startSpeed, DefineClass.PlayerStat_MinSpeed, _so.maxSpeed, DefineClass.PlayerStat_SpeedValue);

        weight = new PlayerStat
            (_so.weight, DefineClass.PlayerStat_MinWeight, DefineClass.PlayerStat_MaxWeight, DefineClass.PlayerStat_WeightValue);

        hp = new PlayerStat
            (_so.maxHP, DefineClass.PlayerStat_MinHP, _so.maxHP, 0.0f);

        mp = new PlayerStat
            (0, DefineClass.PlayerStat_MinMP, _so.maxMP, 0.0f);


        Data = new Dictionary<EStatType, PlayerStat>();

        Data.Add(EStatType.SPD, speed);
        Data.Add(EStatType.WEIGHT, weight);
        Data.Add(EStatType.HP, hp);
        Data.Add(EStatType.MP, mp);
    }
}