using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : PlayerCharacter
{
    //[SerializeField] private GameObject SprintVFXObject;
    //[SerializeField] private GameObject WeightDownVFXObject;
    //[SerializeField] private GameObject ShieldVFXObject;

    protected override void Start()
    {
        base.Start();

        List<SkillBase> _skillList = new List<SkillBase>();

        _skillList.Add(new Skill_Sprinter());
        _skillList.Add(new Skill_Dash());
        _skillList.Add(new Skill_TemporarilyInvincible());
        _skillList.Add(new Skill_WeightDown());
        _skillList.Add(new Skill_AutoDash());

        foreach (SkillBase skill in _skillList) skill.Init(this);

        skillHandler.Init(_skillList.ToArray());
    }
}
