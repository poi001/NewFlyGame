using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;


public class PlayerStatHandler : MonoBehaviour
{
    [SerializeField] private StatScriptableObject statSO;
    private PlayerStatData statData;
    public string characterName { get; private set; }
    public string description { get; private set; }

    public event Action OnDamage;               //����� ���� ��
    public event Action OnHeal;                 //ȸ���� ��
    public event Action OnDeath;                //���� ��
    public event Action OnChangeStat;           //������ ����� ��

    private void Awake()
    {
        //Start�� �ƴ� Awake�� ������ ������ PlayerCharacterŬ�������� StatData�� �޾ƿ;� �ϴµ�
        //�� �������� ���� �����ؾ��ϱ� ������ Awake�� �����ߴ�.
        statData = new PlayerStatData(statSO);

        characterName = statSO.characterName;
        description = statSO.description;
    }

    private void OnDestroy()
    {
        OnDamage = null;
        OnHeal = null;
        OnDeath = null;
        OnChangeStat = null;
    }

    //���� ���� �Լ�
    public void ChangeCurrentStat(EStatType _eStat, int _stat) { statData.Data[_eStat].current = _stat; OnChangeStat?.Invoke(); }
    public void ChangeMinStat(EStatType _eStat, int _stat) { statData.Data[_eStat].min = _stat; OnChangeStat?.Invoke(); }
    public void ChangeMaxStat(EStatType _eStat, int _stat) { statData.Data[_eStat].max = _stat; OnChangeStat?.Invoke(); }
    //������ �޾ƿ��� �Լ�
    public int GetCurrentStat(EStatType _eStat) { return statData.Data[_eStat].current; }
    public int GetMinStat(EStatType _eStat) { return statData.Data[_eStat].min; }
    public int GetMaxStat(EStatType _eStat) { return statData.Data[_eStat].max; }
    public float GetCurrentValueStat(EStatType _eStat) { return statData.Data[_eStat].currentValue_; }
    public float GetValueStat(EStatType _eStat) { return statData.Data[_eStat].value_; }
    public float GetInitStat(EStatType _eStat) { return statData.Data[_eStat].Init; }

    private void Dead()
    {
        OnDeath?.Invoke();

        GameManager.Instance.GameUIEnd();
        GameManager.Instance.UIManager_.GameResultUI_.gameObject.SetActive(true);
    }

    public void Damaged()
    {
        ChangeCurrentStat(EStatType.HP, statData.hp.current - 1);

        OnDamage?.Invoke();

        if (statData.hp.current == 0) Dead();
    }

    public void Healed()
    {
        ChangeCurrentStat(EStatType.HP, statData.hp.current + 1);

        OnHeal?.Invoke();
    }

    //����� ������ ��ȯ��
    public int UseSkill()
    {
        int _sp = 0;

        if (statData.mp.current == 0)
        {
            Debug.LogWarning("������ �����ϴ�.");
            return _sp;
        }
        else
        {
            _sp = statData.mp.current;
            ChangeCurrentStat(EStatType.MP, 0);
        }

        OnChangeStat?.Invoke();

        return _sp;
    }

    public void AddSkillPoint()
    {
        ChangeCurrentStat(EStatType.MP, statData.mp.current + 1);

        OnChangeStat?.Invoke();
    }
}
