using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : PlayerCharacter
{
    //[SerializeField] private GameObject SprintVFXObject;
    //[SerializeField] private GameObject SuperArmorVFXObject;
    //[SerializeField] private GameObject HealVFXObject;
    //[SerializeField] private GameObject ShieldVFXObject;

    protected override void Start()
    {
        base.Start();

        List<SkillBase> _skillList = new List<SkillBase>();

        _skillList.Add(new Skill_Sprinter());
        _skillList.Add(new Skill_Dash());
        _skillList.Add(new Skill_SuperArmor());
        _skillList.Add(new Skill_Heal());
        _skillList.Add(new Skill_Shield());

        foreach (SkillBase skill in _skillList) skill.Init(this);

        skillHandler.Init(_skillList.ToArray());
    }
}
