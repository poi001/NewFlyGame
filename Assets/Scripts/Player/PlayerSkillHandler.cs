using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillHandler : MonoBehaviour
{
    private PlayerCharacter character;
    public BuffSystem buffSystem { get; private set; }
    public SkillBase[] Skills { get; private set; }
    [field: SerializeField] public SkillScriptableObject[] SkillSOs { get; private set; }


    private void Start()
    {
        character = GetComponent<PlayerCharacter>();

        buffSystem = new BuffSystem();

    }

    private void Update()
    {
        if (buffSystem.GetBuffList().Count != 0) buffSystem.Update(Time.deltaTime);
    }

    public void Init(SkillBase[] _skillarr)
    {
        Skills = _skillarr;
    }

    public void ActiveSkill()
    {
        int _mp = character.statHandler.UseSkill();
        if(_mp > 0) Skills[_mp - 1].ActiveSkill();
    }

    public void ChangeStat()
    {

    }
}
