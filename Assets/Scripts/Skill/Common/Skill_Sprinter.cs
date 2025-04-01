using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Skill_Sprinter : SkillBase
{
    private bool isSprint = false;

    public override void ActiveSkill()
    {
        if(!isSprint)
        time = 8.0f;

        character.movement.ChangeSpeed(1.2f);

    }

    public override void DeactiveSkill()
    {

    }
}
