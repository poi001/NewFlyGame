using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Skill_Sprinter : SkillBase
{
    public override void ActiveSkill()
    {
        time = 5.0f;

        CreateBuff(EBuffType.SPRINTER, time);
        OnSprint();
    }

    public override void DeactiveSkill()
    {
        OffSprint();
    }

    private void OnSprint()
    {
        OnSprintSound(1.0f, 0.75f);
        StartSprint();
    }

    private void OffSprint()
    {
        character.movement.AddSpeedStack = 0;
    }

    private void StartSprint()
    {
        character.movement.AddSpeedStack = 2;
    }
}
