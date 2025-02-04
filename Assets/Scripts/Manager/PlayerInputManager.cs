using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    public event Action OnUpDown;
    public event Action OnSprint;
    public event Action OnSkill;

    PlayerAction input;

    private void OnEnable()
    {
        input = new PlayerAction();

        //input.Basic.UpDown.performed
        //input.Basic.Sprint
        //input.Basic.Skill

        input.Enable();
    }

    private void OnDisable()
    {
        //input.Basic.UpDown.performed
        //input.Basic.Sprint
        //input.Basic.Skill

        input.Disable();
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void CallUpDownEvent(InputAction.CallbackContext value)
    {
        OnUpDown?.Invoke();
    }

    public void CallSprintEvent(InputAction.CallbackContext value)
    {
        OnSprint?.Invoke();
    }

    public void CallSkillEvent(InputAction.CallbackContext value)
    {
        OnSkill?.Invoke();
    }
}
