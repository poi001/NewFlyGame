using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Skill_Sprinter : SkillBase
{
    public override void ActiveSkill()
    {
        time = 8.0f;

        CreateBuff(EBuffType.SPRINTER, time);
        OnSprint();
    }

    public override void DeactiveSkill()
    {
        OffSprint();
    }

    private void OnSprint()
    {
        foreach (var item in character.skillHandler.buffSystem.GetBuffList())
        {
            if(item.Type == EBuffType.DASH)
            {
                item.EndBuff += StartSprint;
                return;
            }
        }

        StartSprint();
    }

    private void OffSprint()
    {
        character.movement.SetOffStationaryMoveSpeed(stat.GetCurrentValueStat(EStatType.SPD));
    }

    private void StartSprint()
    {
        int _currentStat = stat.GetCurrentStat(EStatType.SPD);
        float _valueStat = stat.GetValueStat(EStatType.SPD);
        float _speed = _valueStat * (_currentStat + 3);
        character.movement.SetOnStationaryMoveSpeed(_speed);
    }
}
