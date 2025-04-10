using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pigeon : PlayerCharacter
{
    protected override void Start()
    {
        base.Start();

        List<SkillBase> _skillList = new List<SkillBase>();

        _skillList.Add(new Skill_Sprinter());
        _skillList.Add(new Skill_Dash());
        //_skillList[2] = new Skill_Dash();
        //_skillList[3] = new Skill_Dash();

        foreach (SkillBase skill in _skillList) skill.Init(this);

        skillHandler.Init(_skillList.ToArray());
    }


}
