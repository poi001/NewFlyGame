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

        maxStatData = new PlayerStatData(so.maxSpeed, 99, so.maxHP, so.maxMP);
        currentStatData = new PlayerStatData(0, so.weight, so.maxHP, so.maxMP);
    }

    public void ChangeStat(EStat _eStat, int _stat)
    {
        switch (_eStat)
        {
            case EStat.SPD:
                currentStatData.speed = Mathf.Clamp(_stat, 1, maxStatData.speed);
                break;
            case EStat.WEIGHT:
                currentStatData.weight = Mathf.Clamp(_stat, 1, maxStatData.weight);
                break;
            case EStat.HP:
                currentStatData.hp = Mathf.Clamp(_stat, 0, maxStatData.hp);
                if (currentStatData.hp == 0) Dead();
                break;
            case EStat.MP:
                currentStatData.mp = Mathf.Clamp(_stat, 0, maxStatData.mp);
                break;
            default:
                break;
        }
    }

    private void Dead()
    {

    }

    public void Damaged(int _damage)
    {
        ChangeStat(EStat.HP, currentStatData.hp  - _damage);
    }

    public void UseSkill(int _damage)
    {
        if(currentStatData.mp == 0)
        {
            Debug.LogError("마나가 없습니다.");
            return;
        }

        ChangeStat(EStat.MP, 0);
    }
}
