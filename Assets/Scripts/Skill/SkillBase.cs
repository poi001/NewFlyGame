
public interface ISkill
{
    public void Init(PlayerCharacter _player);
    public void ActiveSkill();
    public void DeactiveSkill();
}

public abstract class SkillBase : ISkill
{
    protected PlayerCharacter character;
    protected PlayerStatHandler stat;
    public float time { get; protected set; }
    protected Buff buff;

    public void Init(PlayerCharacter _player)
    {
        character = _player;
        stat = _player.statHandler;
    }

    public abstract void ActiveSkill();

    public virtual void DeactiveSkill() { }

    protected void CreateBuff(EBuffType _buffType, float _time)
    {
        buff = new Buff(_buffType, _time);
        character.skillHandler.buffSystem.AddBuff(buff);
        buff.EndBuff += DeactiveSkill;
    }

    protected void OnSkillSound(float _volume = 1.0f, float _pitch = 1.0f)
    {
        SoundManager.Instance.PlaySFX(SoundManager.ESFXType.SFX_SKILL, _volume, _pitch);
    }

    protected void OnDashSound(float _volume = 1.0f, float _pitch = 1.0f)
    {
        SoundManager.Instance.PlaySFX(SoundManager.ESFXType.SFX_DASH, _volume, _pitch);
    }

    protected void OnSprintSound(float _volume = 1.0f, float _pitch = 1.0f)
    {
        SoundManager.Instance.PlaySFX(SoundManager.ESFXType.SFX_SPRINT, _volume, _pitch);
    }
}
