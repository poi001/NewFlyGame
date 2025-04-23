
public class Skill_WeightDown : SkillBase
{
    public override void ActiveSkill()
    {
        OnSkillSound();
        OnWeightDown();
    }

    private void OnWeightDown()
    {
        int _stack = stat.GetCurrentStat(EStatType.WEIGHT);
        stat.ChangeCurrentStat(EStatType.WEIGHT, _stack + 1);
    }
}
