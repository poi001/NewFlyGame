
public class Skill_SpeedUp : SkillBase
{
    public override void ActiveSkill()
    {
        OnSkillSound();
        OnSpeedUp();
        character.OnVFX(PlayerCharacter.EVFXType.SPEEDUP);
    }

    private void OnSpeedUp()
    {
        int _stack = stat.GetCurrentStat(EStatType.SPD);
        stat.ChangeCurrentStat(EStatType.SPD, _stack + 1);
    }
}
