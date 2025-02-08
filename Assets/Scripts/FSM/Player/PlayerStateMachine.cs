
public class PlayerStateMachine : BaseStateMachine
{
    public PlayerCharacter character;

    public UpState upState {  get; }
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
