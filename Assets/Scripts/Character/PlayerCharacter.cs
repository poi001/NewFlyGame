using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class PlayerCharacter : MonoBehaviour
{
    public Animator animator { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public BoxCollider2D bc { get; private set; }

    [SerializeField] private StatScriptableObject statSO;
    public PlayerStatHandler statHandler { get; protected set; }
    public PlayerStateMachine stateMachine { get; protected set; }
    public PlayerAnimationData animationData { get; protected set; }
    public PlayerMovement movement { get; protected set; }

    private void Awake()
    {
        statHandler = new PlayerStatHandler(statSO);
        stateMachine = new PlayerStateMachine(this);
        animationData = new PlayerAnimationData();

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        movement = GetComponent<PlayerMovement>();
    }

    private void Start()
    {
        GameManager.Instance.Player = this;
        rb.gravityScale = statHandler.statData.weight.currentValue_;
    }

    private void OnDisable()
    {
        if (GameManager.Instance != null && GameManager.Instance.Player != null) GameManager.Instance.Player = null;
    }
}
