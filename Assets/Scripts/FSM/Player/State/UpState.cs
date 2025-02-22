using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpState : PlayerBaseState
{
    public UpState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.currentState_Enum = EPlayerState.UP;
        StartAnimation_Bool(stateMachine.character.animationData.upParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        stateMachine.currentState_Enum = EPlayerState.NONE;
        StopAnimation_Bool(stateMachine.character.animationData.upParameterHash);
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
