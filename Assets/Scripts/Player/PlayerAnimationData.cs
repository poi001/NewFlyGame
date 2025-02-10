using UnityEngine;

public class PlayerAnimationData
{
    [SerializeField] private string upParameterName = "Up";
    [SerializeField] private string sprintParameterName = "Sprint";
    [SerializeField] private string damagedParameterName = "Damaged";

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