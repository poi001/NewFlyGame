
public class Skill_SpeedUp : SkillBase
{
    public override void ActiveSkill()
    {
        OnSpeedUp();
    }

    private void OnSpeedUp()
    {
        int _stack = stat.GetCurrentStat(EStatType.SPD);
        stat.ChangeCurrentStat(EStatType.SPD, _stack + 1);
        //ÆÄÆ¼Å¬
    }
}
