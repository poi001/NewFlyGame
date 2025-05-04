using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_SuperArmor : SkillBase
{
    public override void ActiveSkill()
    {
        time = 9999999.0f;

        CreateBuff(EBuffType.SUPERARMOR, time);
        stat.OnCrash += OnDamaged;
        character.OnVFX(PlayerCharacter.EVFXType.ARMOR);
        OnSkillSound();
    }

    public override void DeactiveSkill()
    {
        stat.OnCrash -= OnDamaged;
        character.OffVFX(PlayerCharacter.EVFXType.ARMOR);
    }

    private void OnDamaged()
    {
        character.skillHandler.buffSystem.DeleteBuff(buff);
    }
}
