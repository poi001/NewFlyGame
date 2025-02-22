public enum EPlayerState
{
    NONE = 0,
    UP = 1,
    DOWN = 2,
    SPRINT = 3,
    SKILL = 4,
    DAMAGE = 5
}

public class PlayerStateMachine : BaseStateMachine
{
    public PlayerCharacter character;
    public EPlayerState currentState_Enum;

    public UpState upState { get; }
    public DownState downState { get; }
    public SprintState sprintState { get; }
    public DamagedState damagedState { get; }
    public SkillState skillState { get; }

    public PlayerStateMachine(PlayerCharacter chara)
    {
        character = chara;

        upState = new UpState(this);
        downState = new DownState(this);
        sprintState = new SprintState(this);
        damagedState = new DamagedState(this);
        skillState = new SkillState(this);
    }
}
