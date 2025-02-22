using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownState : PlayerBaseState
{
    public DownState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.currentState_Enum = EPlayerState.DOWN;
        StopAnimation_Bool(stateMachine.character.animationData.upParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        stateMachine.currentState_Enum = EPlayerState.NONE;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void Update()
    {
        base.Update();
    }
}
