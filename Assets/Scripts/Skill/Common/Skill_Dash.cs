using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Skill_Dash : SkillBase
{
    int beforeSpeed;

    public override void ActiveSkill()
    {
        time = 1.0f;
        beforeSpeed = character.statHandler.statData.speed.current;

        CreateBuff(EBuffType.DASH, time);

        OnDash();
    }

    public override void DeactiveSkill()
    {
        OffDash();
    }

    private void OnDash()
    {
        character.motionTrail.OnMotionTrail(time);
        character.gameObject.layer = DefineClass.Layer_PlayerDamaged;
        character.movement.ChangeSpeed(character.statHandler.statData.speed.max, 2.0f);
    }

    private void OffDash()
    {
        character.gameObject.layer = DefineClass.Layer_Player;
        character.movement.ChangeSpeed(beforeSpeed);
    }
}
