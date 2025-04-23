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

    private bool isStationaryMoveSpeed = false;

    Coroutine blinkCoroutine_;

    public int AddSpeedStack = 0;

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
            GameManager.Instance.ActiveParticle(EParticleType.CRASH, gameObject.transform.position);
            SoundManager.Instance.PlaySFX(SoundManager.ESFXType.SFX_CRASH);
        }
    }

    private void OnSubs()
    {
        input.OnUp += MoveUp;
        input.OnDown += MoveDown;
        input.OnSprint += OnSprint;
        input.OffSprint += MoveForward;
        input.OnSkill += OnSkill;

        character.statHandler.OnChangeStat += UpdateMovementStat;
    }

    private void OffSubs()
    {
        input.OnUp -= MoveUp;
        input.OnDown -= MoveDown;
        input.OnSprint -= OnSprint;
        input.OffSprint -= MoveForward;
        input.OnSkill -= OnSkill;

        character.statHandler.OnChangeStat -= UpdateMovementStat;
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
        if (!isStationaryMoveSpeed)
        {
            float _addSpeed = character.statHandler.GetValueStat(EStatType.SPD) * AddSpeedStack;
            float _currentSpeed = character.statHandler.GetCurrentValueStat(EStatType.SPD) + _addSpeed;
            if (isSprint) speed = _currentSpeed * 2.0f;
            else speed = _currentSpeed;
        }

        //Weight
        float _currentWeight = character.statHandler.GetCurrentValueStat(EStatType.WEIGHT);
        if (isUp) weight = _currentWeight * -2.0f;
        else weight = _currentWeight;

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

        rb.velocity = Vector2.zero;
        rb.AddForce(new Vector2(-5.0f, 1.0f), ForceMode2D.Impulse);

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

    private void UpdateMovementStat()
    {
        if(!isStationaryMoveSpeed) speed = character.statHandler.GetCurrentValueStat(EStatType.SPD);
        weight = character.statHandler.GetCurrentValueStat(EStatType.WEIGHT);
    }

    public void SetOnStationaryMoveSpeed(float _spd)
    {
        if(!isStationaryMoveSpeed)
        {
            isStationaryMoveSpeed = true;
            speed = _spd;
        }
    }

    public void SetOffStationaryMoveSpeed(float _spd)
    {
        if (isStationaryMoveSpeed)
        {
            isStationaryMoveSpeed = false;
            speed = character.statHandler.GetCurrentValueStat(EStatType.SPD);
        }
    }
}
