using UnityEngine;

public class PlayerAnimationData
{
    [SerializeField] private string upParameterName = DefineClass.PlayerAnimationParameter_Up;
    [SerializeField] private string sprintParameterName = DefineClass.PlayerAnimationParameter_Sprint;
    [SerializeField] private string damagedParameterName = DefineClass.PlayerAnimationParameter_Damaged;

    public int upParameterHash { get; private set; }
    public int sprintParameterHash { get; private set; }
    public int damagedParameterHash { get; private set; }


    public PlayerAnimationData()
    {
        Initialize();
    }

    public void Initialize()
    {
        upParameterHash = Animator.StringToHash(upParameterName);
        sprintParameterHash = Animator.StringToHash(sprintParameterName);
        damagedParameterHash = Animator.StringToHash(damagedParameterName);
    }
}