using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStatHandler
{
    StatScriptableObject statSO;
    public PlayerStatData statData { get; private set; }
    public string characterName { get; private set; }
    public string description { get; private set; }


    public PlayerStatHandler(StatScriptableObject so)
    {
        InitializeStat(so);
    }

    void InitializeStat(StatScriptableObject so)
    {
        statSO = so;
        statData = new PlayerStatData(so);
    }

    public void ChangeStat(EStat _eStat, int _stat)
    {
        switch (_eStat)
        {
            case EStat.SPD:
                statData.speed.current = _stat;
                break;
            case EStat.WEIGHT:
                statData.weight.current = _stat;
                break;
            case EStat.HP:
                statData.hp.current = _stat;
                break;
            case EStat.MP:
                statData.mp.current = _stat;
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
        ChangeStat(EStat.HP, statData.hp.current - _damage);

        if(statData.hp.current == 0) Dead();
    }

    public void UseSkill(int _sp)
    {
        if (statData.mp.current == 0)
        {
            Debug.LogError("마나가 없습니다.");
            return;
        }
        else ChangeStat(EStat.MP, statData.mp.current - _sp);
    }
}
