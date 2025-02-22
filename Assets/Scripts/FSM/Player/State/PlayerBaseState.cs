using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseState : IState
{
    protected PlayerStateMachine stateMachine;

    public PlayerBaseState(PlayerStateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
    }

    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }

    public virtual void Update()
    {

    }

    protected void StartAnimation_Bool(int animationHash)
    {
        stateMachine.character.animator.SetBool(animationHash, true);
    }
    protected void StopAnimation_Bool(int animationHash)
    {
        stateMachine.character.animator.SetBool(animationHash, false);
    }
    protected void StartAnimation_Trigger(int animationHash)
    {
        stateMachine.character.animator.SetTrigger(animationHash);
    }
}
