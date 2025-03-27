using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerStatHandler
{
    StatScriptableObject statSO;
    public PlayerStatData statData { get; private set; }
    public string characterName { get; private set; }
    public string description { get; private set; }

    public event Action OnDamage;           //����� ���� ��
    public event Action OnHeal;             //ȸ���� ��
    public event Action OnDeath;            //���� ��
    public event Action OnChangeSkillPoint; //��ų����Ʈ�� ����� ��


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
        OnDeath.Invoke();
    }

    public void Damaged()
    {
        ChangeStat(EStat.HP, statData.hp.current - 1);

        OnDamage.Invoke();

        if (statData.hp.current == 0) Dead();
    }

    public void Healed()
    {
        ChangeStat(EStat.HP, statData.hp.current + 1);

        OnHeal.Invoke();
    }

    public void UseSkill()
    {
        if (statData.mp.current == 0)
        {
            Debug.LogWarning("������ �����ϴ�.");
            return;
        }
        else ChangeStat(EStat.MP, 0);

        OnChangeSkillPoint.Invoke();
    }

    public void GetSkillPoint()
    {
        ChangeStat(EStat.MP, statData.mp.current + 1);

        OnChangeSkillPoint.Invoke();
    }
}
