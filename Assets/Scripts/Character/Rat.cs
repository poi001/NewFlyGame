using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : PlayerCharacter
{
    //[SerializeField] private GameObject SpeedUpVFXObject;

    protected override void Start()
    {
        base.Start();

        List<SkillBase> _skillList = new List<SkillBase>();

        _skillList.Add(new Skill_Dash());
        _skillList.Add(new Skill_Lighting());
        _skillList.Add(new Skill_SpeedUp());

        foreach (SkillBase skill in _skillList) skill.Init(this);

        skillHandler.Init(_skillList.ToArray());
    }
}
