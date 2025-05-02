using System.Collections;
using UnityEngine;
using static UnityEngine.ParticleSystem;


public class PlayerCharacter : MonoBehaviour
{
    public Animator animator { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public BoxCollider2D bc { get; private set; }

    public PlayerStateMachine stateMachine { get; protected set; }
    public PlayerAnimationData animationData { get; protected set; }

    public PlayerStatHandler statHandler { get; protected set; }
    public PlayerMovement movement { get; protected set; }
    public MotionTrail motionTrail { get; protected set; }
    public PlayerSkillHandler skillHandler { get; protected set; }

    private void Awake()
    {
        stateMachine = new PlayerStateMachine(this);
        animationData = new PlayerAnimationData();

        statHandler = GetComponent<PlayerStatHandler>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        movement = GetComponent<PlayerMovement>();
        motionTrail = GetComponent<MotionTrail>();
        skillHandler = GetComponent<PlayerSkillHandler>();
    }

    protected virtual void Start()
    {
        GameManager.Instance.Player = this;
        rb.gravityScale = statHandler.GetCurrentValueStat(EStatType.WEIGHT);

        statHandler.OnDeath += OnDeadPlayer;
    }

    private void OnDisable()
    {
        statHandler.OnDeath -= OnDeadPlayer;
    }

    private void OnDeadPlayer()
    {
        Instantiate(GameManager.Instance.Particles.CrashParticle, transform.position, Quaternion.identity).transform.localScale
            = new Vector2(10.0f, 10.0f);
        movement.Idle();
        StartCoroutine(Coroutine_DestroyPlayer());
    }

    IEnumerator Coroutine_DestroyPlayer()
    {
        yield return new WaitForSecondsRealtime(2.0f);
        GameManager.Instance.GameUIEnd();
        GameManager.Instance.UIManager_.GameResultUI_.gameObject.SetActive(true);
        GameManager.Instance.Player = null;
        Destroy(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            skillHandler.ActiveSkill(5);
        }
    }
}
