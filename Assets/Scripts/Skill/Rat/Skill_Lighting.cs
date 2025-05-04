using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Lighting : SkillBase
{
    public override void ActiveSkill()
    {
        time = 7.0f;

        CreateBuff(EBuffType.LIGHTWEIGHT, time);
        OnLighting();
        character.OnVFX(PlayerCharacter.EVFXType.WEIGHTDOWN);
    }

    public override void DeactiveSkill()
    {
        OffLighting();
        character.OffVFX(PlayerCharacter.EVFXType.WEIGHTDOWN);
    }

    private void OnLighting()
    {
        OnSkillSound();
        StartLighting();
    }

    private void OffLighting()
    {
        character.gameObject.transform.localScale = new Vector2(2.0f, 2.0f);
    }

    private void StartLighting()
    {
        character.gameObject.transform.localScale = new Vector2(1.0f, 1.0f);
    }
}
