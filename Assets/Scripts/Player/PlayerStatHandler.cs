using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStatHandler
{
    StatScriptableObject statSO;

    public string characterName { get; private set; }
    public string description { get; private set; }
    public int currentSpeed { get; private set; }
    public int maxSpeed { get; private set; }
    public float currentWeight { get; private set; }
    public int currentHP { get; private set; }
    public int maxHP { get; private set; }
    public int currentMP { get; private set; }
    public int maxMP { get; private set; }

    public PlayerStatHandler(StatScriptableObject so)
    {
        InitializeStat(so);
    }

    void InitializeStat(StatScriptableObject so)
    {
        statSO = so;
        characterName = so.characterName;
        description = so.description;
        maxSpeed = so.maxSpeed;
        currentWeight = so.weight;
        maxHP = so.maxHP;
        maxMP = so.maxMP;

        currentSpeed = 1;
        currentHP = maxHP;
        currentMP = maxMP;
    }

    private void ClampStat()
    {

    }
}
