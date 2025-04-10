using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;


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
    }

    private void OnDisable()
    {
        if (GameManager.Instance != null && GameManager.Instance.Player != null) GameManager.Instance.Player = null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            statHandler.AddSkillPoint();
            statHandler.AddSkillPoint();
            skillHandler.ActiveSkill();
        }
    }
}
