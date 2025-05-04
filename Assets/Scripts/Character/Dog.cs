using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : PlayerCharacter
{
    [SerializeField] private GameObject SprintVFXObject;
    [SerializeField] private GameObject SuperArmorVFXObject;
    [SerializeField] private GameObject HealVFXObject;
    [SerializeField] private GameObject ShieldVFXObject;

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

    public override void OnVFX(EVFXType _vfxType)
    {
        switch (_vfxType)
        {
            case EVFXType.SPRINT:
                SprintVFXObject.SetActive(true);
                break;
            case EVFXType.ARMOR:
                SuperArmorVFXObject.SetActive(true);
                break;
            case EVFXType.SHIELD:
                ShieldVFXObject.SetActive(true);
                break;
            case EVFXType.HEAL:
                HealVFXObject.SetActive(true);
                StartCoroutine(Coroutine_OffHealVFX());
                break;
            default:
                break;
        }
    }
    public override void OffVFX(EVFXType _vfxType)
    {
        switch (_vfxType)
        {
            case EVFXType.SPRINT:
                SprintVFXObject.SetActive(false);
                break;
            case EVFXType.ARMOR:
                SuperArmorVFXObject.SetActive(false);
                break;
            case EVFXType.SHIELD:
                ShieldVFXObject.SetActive(false);
                break;
            case EVFXType.HEAL:
                HealVFXObject.SetActive(false);
                break;
            default:
                break;
        }
    }

    IEnumerator Coroutine_OffHealVFX()
    {
        yield return new WaitForSeconds(0.42f);
        OffVFX(EVFXType.HEAL);
    }
}
