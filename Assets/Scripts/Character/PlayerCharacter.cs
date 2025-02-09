using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCharacter : MonoBehaviour
{
    protected Animator animator;
    protected Rigidbody2D rb;
    protected BoxCollider2D bc;

    [SerializeField] private StatScriptableObject statSO;
    public PlayerStatHandler statHandler;

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
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();

        rb.gravityScale = weight;
    }
}
