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

    private Vector2 dir = Vector2.zero;

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
        //Debug.Log(dir);//temp
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
        //rb.gravityScale = character.currentWeight * -2.0f;
        rb.gravityScale = -12.0f;
    }

    private void MoveDown()
    {
        //rb.gravityScale = character.currentWeight;
        rb.gravityScale = 6.0f;
    }

    private void OnSprint()
    {
        dir = Vector2.right * character.speed * 2.0f;
    }

    private void MoveForward()
    {
        dir = Vector2.right * character.speed;
    }

    private void ApplyMovement(Vector2 direction)
    {
        rb.AddForce(direction);
        CheckGravity();
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
