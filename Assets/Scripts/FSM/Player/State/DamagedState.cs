using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedState : PlayerBaseState
{

    public DamagedState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.currentState_Enum = EPlayerState.DAMAGE;
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
