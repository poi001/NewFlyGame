using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;


public class PlayerStatHandler : MonoBehaviour
{
    [SerializeField] private StatScriptableObject statSO;
    public PlayerStatData statData { get; private set; }
    public string characterName { get; private set; }
    public string description { get; private set; }

    public event Action OnDamage;           //����� ���� ��
    public event Action OnHeal;             //ȸ���� ��
    public event Action OnDeath;            //���� ��
    public event Action OnChangeSkillPoint; //��ų����Ʈ�� ����� ��

    private void Awake()
    {
        //Start�� �ƴ� Awake�� ������ ������ PlayerCharacterŬ�������� StatData�� �޾ƿ;� �ϴµ�
        //�� �������� ���� �����ؾ��ϱ� ������ Awake�� �����ߴ�.
        statData = new PlayerStatData(statSO);
        characterName = statSO.characterName;
        description = statSO.description;
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
        OnDeath?.Invoke();

        Time.timeScale = 0;

        GameManager.Instance.UIManager_.GameResultUI_.gameObject.SetActive(true);
    }

    public void Damaged()
    {
        ChangeStat(EStat.HP, statData.hp.current - 1);

        OnDamage?.Invoke();

        if (statData.hp.current == 0) Dead();
    }

    public void Healed()
    {
        ChangeStat(EStat.HP, statData.hp.current + 1);

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
            ChangeStat(EStat.MP, 0);
        }

        OnChangeSkillPoint?.Invoke();

        return _sp;
    }

    public void AddSkillPoint()
    {
        ChangeStat(EStat.MP, statData.mp.current + 1);

        OnChangeSkillPoint?.Invoke();
    }

    public void ActiveBuff(PlayerCharacter _player, EBuffType _buffType)
    {
        switch (_buffType)
        {
            case EBuffType.SPRINTER:
                {
                    //_player.motionTrail.OnMotionTrail(time);
                    //character.gameObject.layer = DefineClass.Layer_PlayerDamaged;
                    //character.movement.ChangeSpeed(character.statHandler.statData.speed.max, 2.0f);
                }
                break;

            case EBuffType.LIGHTWEIGHT:
                {

                }
                break;

            case EBuffType.DASH:
                {

                }
                break;

            case EBuffType.SPEEDUP:
                {

                }
                break;

            default:
                break;
        }
    }
}
