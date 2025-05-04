using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : PlayerCharacter
{
    [SerializeField] private GameObject LightingVFXObject;
    [SerializeField] private GameObject SpeedUpVFXObject;

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

    public override void OnVFX(EVFXType _vfxType)
    {
        switch (_vfxType)
        {
            case EVFXType.WEIGHTDOWN:
                LightingVFXObject.SetActive(true);
                StartCoroutine(Coroutine_OffLightingVFX());
                break;
            case EVFXType.SPEEDUP:
                SpeedUpVFXObject.SetActive(true);
                StartCoroutine(Coroutine_OffSpeedUpVFX());
                break;
            default:
                break;
        }
    }
    public override void OffVFX(EVFXType _vfxType)
    {
        switch (_vfxType)
        {
            case EVFXType.WEIGHTDOWN:
                LightingVFXObject.SetActive(false);
                break;
            case EVFXType.SPEEDUP:
                SpeedUpVFXObject.SetActive(false);
                break;
            default:
                break;
        }
    }

    IEnumerator Coroutine_OffLightingVFX()
    {
        yield return new WaitForSeconds(0.42f);
        OffVFX(EVFXType.WEIGHTDOWN);
    }
    IEnumerator Coroutine_OffSpeedUpVFX()
    {
        yield return new WaitForSeconds(0.42f);
        OffVFX(EVFXType.SPEEDUP);
    }
}
