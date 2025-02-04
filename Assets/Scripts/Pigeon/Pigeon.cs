using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pigeon : MonoBehaviour
{
    private Animator animator;

    private PlayerInputManager input;

    void Start()
    {
        animator = GetComponent<Animator>();

        input = GetComponent<PlayerInputManager>();
    }

    void Update()
    {
        
    }
}
