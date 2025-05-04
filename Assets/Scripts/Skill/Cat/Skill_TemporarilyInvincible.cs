using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_TemporarilyInvincible : SkillBase
{
    public override void ActiveSkill()
    {
        time = 3.0f;

        character.movement.Invincible(time);
        OnSkillSound();
    }
}
