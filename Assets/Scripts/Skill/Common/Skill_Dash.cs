
public class Skill_Dash : SkillBase
{
    public override void ActiveSkill()
    {
        time = 1.0f;

        OnDashSound(1.0f, 1.2f);
        CreateBuff(EBuffType.DASH, time);
        OnDash();
    }

    public override void DeactiveSkill()
    {
        OffDash();
    }

    private void OnDash()
    {
        character.motionTrail.OnMotionTrail(time, 0.05f);
        character.gameObject.layer = DefineClass.Layer_PlayerDamaged;
        character.movement.SetOnStationaryMoveSpeed(stat.GetValueStat(EStatType.SPD) * stat.GetMaxStat(EStatType.SPD) * 2.0f);
    }

    private void OffDash()
    {
        character.gameObject.layer = DefineClass.Layer_Player;
        character.movement.SetOffStationaryMoveSpeed(stat.GetCurrentValueStat(EStatType.SPD));
    }
}
