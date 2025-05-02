using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_AutoDash : SkillBase
{
    public override void ActiveSkill()
    {
        time = 9999999.0f;

        CreateBuff(EBuffType.SHIELD, time);

        //OnDashSound(1.0f, 1.2f);
        stat.OnDamage += OnDamaged;
    }

    public override void DeactiveSkill()
    {
        stat.OnDamage -= OnDamaged;
        //¿Ã∆Â∆Æ ªË¡¶
    }

    private void OnDamaged()
    {
        character.skillHandler.ActiveSkill(2);
        character.skillHandler.buffSystem.DeleteBuff(buff);
    }
}
