using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCharacter : MonoBehaviour
{
    //[field:SerializeField] public Animator animator { get; private set; }
    public Animator animator { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public BoxCollider2D bc { get; private set; }

    [SerializeField] private StatScriptableObject statSO;
    public PlayerStatHandler statHandler { get; protected set; }
    public PlayerStateMachine stateMachine { get; protected set; }
    public PlayerAnimationData animationData { get; protected set; }

    //Temporary
    //Max
    public int maxHP = 5;
    public int maxMP = 5;
    public float speed = 15.0f;
    public float maxSpeed = 60.0f;
    public float weight = 6.0f;
        //Current
    public int currentHP = 5;
    public int currentMP = 0;

    private void Awake()
    {
        statHandler = new PlayerStatHandler(statSO);
        stateMachine = new PlayerStateMachine(this);
        animationData = new PlayerAnimationData();

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        rb.gravityScale = weight;
    }
}
