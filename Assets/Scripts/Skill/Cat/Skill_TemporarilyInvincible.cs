using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_TemporarilyInvincible : SkillBase
{
    public override void ActiveSkill()
    {
        time = 5.0f;

        character.movement.KnockBack(3.0f);
    }
}
