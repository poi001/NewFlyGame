using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;
using UnityEngine.U2D;

public class PlayerMovement : MonoBehaviour
{
    PlayerInputManager input;
    Rigidbody2D rb;
    PlayerCharacter character;
    SpriteRenderer sprite;

    private Vector2 dir = Vector2.right;
    private float speed;
    private float weight;

    private bool isSprint = false;
    private bool isUp = false;

    Coroutine blinkCoroutine_;

    private void Start()
    {
        input = GetComponent<PlayerInputManager>();
        rb = GetComponent<Rigidbody2D>();
        character = GetComponent<PlayerCharacter>();
        sprite = GetComponent<SpriteRenderer>();

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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(DefineClass.Tag_Obstacle))
        {
            OnDamaged();
        }
    }

    private void OnSubs()
    {
        input.OnUp += MoveUp;
        input.OnDown += MoveDown;
        input.OnSprint += OnSprint;
        input.OffSprint += MoveForward;
        input.OnSkill += OnSkill;
    }

    private void OffSubs()
    {
        input.OnUp -= MoveUp;
        input.OnDown -= MoveDown;
        input.OnSprint -= OnSprint;
        input.OffSprint -= MoveForward;
        input.OnSkill -= OnSkill;
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

    private void OnSkill()
    {
        character.skillHandler.ActiveSkill();
    }

    private void ApplyMovement(Vector2 direction)
    {
        //Speed
        if (isSprint) ChangeSpeed(2.0f);
        else ChangeSpeed(1.0f);

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

    private void OnDamaged()
    {
        gameObject.layer = DefineClass.Layer_PlayerDamaged;

        blinkCoroutine_ = StartCoroutine(StartBlinkPlayer());
        Invoke("StopBlinkPlayer", 1.0f);

        rb.AddForce(new Vector2(-10.0f, 1.0f), ForceMode2D.Impulse);

        character.statHandler.Damaged();
    }

    IEnumerator StartBlinkPlayer()
    {
        Color colorAlpha_ = sprite.color;

        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            colorAlpha_.a = 0.3f;
            sprite.color = colorAlpha_;

            yield return new WaitForSeconds(0.1f);
            colorAlpha_.a = 1.0f;
            sprite.color = colorAlpha_;
        }
    }

    private void StopBlinkPlayer()
    {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1.0f);
        StopCoroutine(blinkCoroutine_);

        gameObject.layer = DefineClass.Layer_Player;
    }

    //스피드 설정(배속 있는 버전)
    public void ChangeSpeed(int _speedStack, float _multiply)
    {
        character.statHandler.statData.speed.current = _speedStack;
        speed = character.statHandler.statData.speed.currentValue_ * _multiply;
    }

    //스피드 설정(배속 없는 버전, 1배)
    public void ChangeSpeed(int _speedStack)
    {
        character.statHandler.statData.speed.current = _speedStack;
        speed = character.statHandler.statData.speed.currentValue_;
    }

    //스피드 설정(배속만 있는 버전, 주의: 2배 후, 0.5배 하면 원상태로 돌아가는게 아닌 원래속도의 0.5배로 설정됨)
    public void ChangeSpeed(float _multiply)
    {
        speed = character.statHandler.statData.speed.currentValue_ * _multiply;
    }
}
