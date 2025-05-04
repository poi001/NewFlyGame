using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_AutoDash : SkillBase
{
    public override void ActiveSkill()
    {
        time = 9999999.0f;

        CreateBuff(EBuffType.SHIELD, time);
        stat.OnCrash += OnDamaged;
        character.OnVFX(PlayerCharacter.EVFXType.SHIELD);
        OnSkill2Sound();
    }

    public override void DeactiveSkill()
    {
        stat.OnCrash -= OnDamaged;
        character.OffVFX(PlayerCharacter.EVFXType.SHIELD);
    }

    private void OnDamaged()
    {
        character.skillHandler.ActiveSkill(2);
        character.skillHandler.buffSystem.DeleteBuff(buff);
    }
}
