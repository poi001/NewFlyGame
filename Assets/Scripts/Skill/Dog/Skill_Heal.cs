using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Heal : SkillBase
{
    public override void ActiveSkill()
    {
        stat.Healed();
        character.OnVFX(PlayerCharacter.EVFXType.HEAL);
        OnSkill2Sound();
    }
}
