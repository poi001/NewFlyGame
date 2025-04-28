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

    public event Action OnDamage;               //대미지 받을 때
    public event Action OnHeal;                 //회복할 때
    public event Action OnDeath;                //죽을 때
    public event Action OnChangeStat;           //스탯이 변경될 때

    private void Awake()
    {
        //Start가 아닌 Awake에 선언한 이유는 PlayerCharacter클래스에서 StatData를 받아와야 하는데
        //그 시점보다 먼저 선언해야하기 떄문에 Awake에 선언했다.
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

    //스탯 변경 함수
    public void ChangeCurrentStat(EStatType _eStat, int _stat) { statData.Data[_eStat].current = _stat; OnChangeStat?.Invoke(); }
    public void ChangeMinStat(EStatType _eStat, int _stat) { statData.Data[_eStat].min = _stat; OnChangeStat?.Invoke(); }
    public void ChangeMaxStat(EStatType _eStat, int _stat) { statData.Data[_eStat].max = _stat; OnChangeStat?.Invoke(); }
    //스탯을 받아오는 함수
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

    //사용한 마나를 반환함
    public int UseSkill()
    {
        int _sp = 0;

        if (statData.mp.current == 0)
        {
            Debug.LogWarning("마나가 없습니다.");
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
