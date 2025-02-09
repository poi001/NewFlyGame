using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStatHandler
{
    StatScriptableObject statSO;
    public PlayerStatData maxStatData { get; private set; }
    public PlayerStatData currentStatData { get; private set; }
    public string characterName { get; private set; }
    public string description { get; private set; }


    public PlayerStatHandler(StatScriptableObject so)
    {
        InitializeStat(so);
    }

    void InitializeStat(StatScriptableObject so)
    {
        statSO = so;

        maxStatData = new PlayerStatData(so.maxSpeed, so.weight, so.maxHP, so.maxMP);
        currentStatData = new PlayerStatData(so.maxSpeed, so.weight, so.maxHP, so.maxMP);
    }

    //½ºÅÈ¹Ù²î´Â ÇÔ¼ö ±¸Çö
}
