using System.Collections;
using UnityEngine;

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
    private bool isDead = false;
    private bool isStationaryMoveSpeed = false;

    Coroutine blinkCoroutine_;

    public int AddSpeedStack = 0;

    private bool isInvincibleMode = false;
    private float invincibleTimer = 0.0f;

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

    private void Update()
    {
        if (isInvincibleMode)
        {
            invincibleTimer -= Time.deltaTime;

            if (invincibleTimer <= 0.0f)
            {
                isInvincibleMode = false;
                StopBlinkPlayer();
            }
        }
    }

    private void FixedUpdate()
    {
        ApplyMovement(dir);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool shield_ = false;
        bool armor_ = false;

        if (collision.gameObject.CompareTag(DefineClass.Tag_Obstacle))
        {
            foreach (var skill in character.skillHandler.buffSystem.GetBuffList())
            {
                if (skill.Type == EBuffType.SHIELD) shield_ = true;
                else if (skill.Type == EBuffType.SUPERARMOR) armor_ = true;
            }

            if (shield_)
            {
                if (armor_) Invincible(1.0f);
                else
                {
                    KnockBack();
                    Invincible(1.0f);
                }
            }
            else if (armor_)
            {
                if(shield_) Invincible(1.0f);
                else
                {
                    character.statHandler.Damaged();
                    Invincible(1.0f);
                }
            }
            else OnDamaged();

            GameManager.Instance.ActiveParticle(EParticleType.CRASH, gameObject.transform.position);
            SoundManager.Instance.PlaySFX(SoundManager.ESFXType.SFX_CRASH);
            character.statHandler.Crashed();
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
        character.statHandler.OnDeath += PlayerIsDead;
    }

    private void OffSubs()
    {
        input.OnUp -= MoveUp;
        input.OnDown -= MoveDown;
        input.OnSprint -= OnSprint;
        input.OffSprint -= MoveForward;
        input.OnSkill -= OnSkill;

        character.statHandler.OnChangeStat -= UpdateMovementStat;
        character.statHandler.OnDeath -= PlayerIsDead;
    }

    private void MoveUp()
    {
        if (!isDead)
        {
            isUp = true;
            if (character.stateMachine.currentState_Enum != EPlayerState.SPRINT)
                character.stateMachine.ChanageState(character.stateMachine.upState);
        }
        else Idle();
    }

    private void MoveDown()
    {
        if (!isDead)
        {
            isUp = false;
            if (character.stateMachine.currentState_Enum != EPlayerState.SPRINT)
                character.stateMachine.ChanageState(character.stateMachine.downState);
        }
        else Idle();
    }

    private void OnSprint()
    {
        if (!isDead)
        {
            dir = Vector2.right;
            isSprint = true;
            character.stateMachine.ChanageState(character.stateMachine.sprintState);
        }
        else Idle();
    }

    private void MoveForward()
    {
        dir = Vector2.right;
        isSprint = false;
        character.stateMachine.ChanageState(character.stateMachine.downState);
    }

    public void Idle()
    {
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
        if (isUp) weight = _currentWeight * -1.0f;
        else weight = character.statHandler.GetValueStat(EStatType.WEIGHT) * character.statHandler.GetInitStat(EStatType.WEIGHT);

        //Movement
        if(!isDead)
        {
            rb.AddForce(direction * speed);
            rb.gravityScale = weight;
        }
        else
        {
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0.0f;
        }

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
        if (rb.velocity.y > 10.0f)
        {
            float x = rb.velocity.x;
            rb.velocity = new Vector2(x, 7.5f);
        }
    }

    private void OnDamaged()
    {
        KnockBack();
        Invincible(1.0f);

        character.statHandler.Damaged();
    }

    public void KnockBack()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(new Vector2(-5.0f, 1.0f), ForceMode2D.Impulse);
    }

    public void Invincible(float _time)
    {
        isInvincibleMode = true;
        invincibleTimer = _time;

        gameObject.layer = DefineClass.Layer_PlayerDamaged;

        if (blinkCoroutine_ != null) StopCoroutine(blinkCoroutine_);
        blinkCoroutine_ = StartCoroutine(StartBlinkPlayer());
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

    private void PlayerIsDead()
    {
        isDead = true;
    }
}
