using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class PlayerMovement : MonoBehaviour
{
    PlayerInputManager input;
    Rigidbody2D rb;
    PlayerCharacter character;

    private Vector2 dir = Vector2.right;
    private float speed;
    private float weight;

    private bool isSprint = false;
    private bool isUp = false;

    private void Start()
    {
        input = GetComponent<PlayerInputManager>();
        rb = GetComponent<Rigidbody2D>();
        character = GetComponent<PlayerCharacter>();

        OnSubs();
        MoveForward();
    }

    private void OnDestroy()
    {
        OffSubs();
    }

    private void FixedUpdate()
    {
        ApplyMovement(dir);
        Debug.Log(rb.velocity.x);
    }

    private void OnSubs()
    {
        input.OnUp += MoveUp;
        input.OnDown += MoveDown;
        input.OnSprint += OnSprint;
        input.OffSprint += MoveForward;
    }

    private void OffSubs()
    {
        input.OnUp -= MoveUp;
        input.OnDown -= MoveDown;
        input.OnSprint -= OnSprint;
        input.OffSprint -= MoveForward;
    }

    private void MoveUp()
    {
        isUp = true;
        if(character.stateMachine.currentState_Enum != EPlayerState.SPRINT)
            character.stateMachine.ChanageState(character.stateMachine.upState);
    }

    private void MoveDown()
    {
        isUp = false;
        if (character.stateMachine.currentState_Enum != EPlayerState.SPRINT)
            character.stateMachine.ChanageState(character.stateMachine.downState);
    }

    private void OnSprint()
    {
        dir = Vector2.right;
        isSprint = true;
        character.stateMachine.ChanageState(character.stateMachine.sprintState);
    }

    private void MoveForward()
    {
        dir = Vector2.right;
        isSprint = false;
        character.stateMachine.ChanageState(character.stateMachine.downState);
    }

    private void ApplyMovement(Vector2 direction)
    {
        //Speed
        if (isSprint) speed = character.statHandler.statData.speed.currentValue_ * 2.0f;
        else speed = character.statHandler.statData.speed.currentValue_;

        //Weight
        if (isUp) weight = character.statHandler.statData.weight.currentValue_ * -2.0f;
        else weight = character.statHandler.statData.weight.currentValue_;

        //Movement
        rb.AddForce(direction * speed);
        rb.gravityScale = weight;

        //속도 제한 함수 구현
        CheckSpeed();
        CheckGravity();
    }

    private void CheckSpeed()
    {
        if (rb.velocity.x > speed * 1.5f)
        {
            float y = rb.velocity.y;
            rb.velocity = new Vector2(speed * 1.5f, y);
        }
    }

    private void CheckGravity()
    {
        if (rb.velocity.y < -15.0f)
        {
            float x = rb.velocity.x;
            rb.velocity = new Vector2(x, -15.0f);
        }
        if (rb.velocity.y > 7.5f)
        {
            float x = rb.velocity.x;
            rb.velocity = new Vector2(x, 7.5f);
        }
    }
}
