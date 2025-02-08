using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    public event Action OnUp;
    public event Action OnDown;
    public event Action OnSprint;
    public event Action OffSprint;
    public event Action OnSkill;

    PlayerAction input;

    private void OnEnable()
    {
        OnSubs();
    }

    private void OnDisable()
    {
        OffSubs();
    }

    private void OnSubs()
    {
        input = new PlayerAction();

        input.Basic.UpDown.performed += CallUpEvent;
        input.Basic.UpDown.canceled += CallDownEvent;
        input.Basic.Sprint.performed += CallOnSprintEvent;
        input.Basic.Sprint.canceled += CallOffSprintEvent;
        input.Basic.Skill.started += CallSkillEvent;

        input.Enable();
    }

    private void OffSubs()
    {
        input.Basic.UpDown.performed -= CallUpEvent;
        input.Basic.UpDown.canceled -= CallDownEvent;
        input.Basic.Sprint.performed -= CallOnSprintEvent;
        input.Basic.Sprint.canceled -= CallOffSprintEvent;
        input.Basic.Skill.started -= CallSkillEvent;

        input.Disable();
    }

    public void CallUpEvent(InputAction.CallbackContext value)
    {
        OnUp?.Invoke();
    }

    public void CallDownEvent(InputAction.CallbackContext value)
    {
        OnDown?.Invoke();
    }

    public void CallOnSprintEvent(InputAction.CallbackContext value)
    {
        OnSprint?.Invoke();
    }

    public void CallOffSprintEvent(InputAction.CallbackContext value)
    {
        OffSprint?.Invoke();
    }

    public void CallSkillEvent(InputAction.CallbackContext value)
    {
        OnSkill?.Invoke();
    }
}
