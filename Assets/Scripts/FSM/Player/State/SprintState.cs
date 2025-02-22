using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintState : PlayerBaseState
{
    public SprintState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.currentState_Enum = EPlayerState.SPRINT;
        StartAnimation_Bool(stateMachine.character.animationData.sprintParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        stateMachine.currentState_Enum = EPlayerState.NONE;
        StopAnimation_Bool(stateMachine.character.animationData.sprintParameterHash);
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
