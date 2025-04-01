using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum EBuffType
{
    NONE = 0,
    SPRINTER = 1,
    LIGHTWEIGHT = 2,
    DASH = 3,
    SPEEDUP = 4
}

public class Buff
{
    public EBuffType Type { get; private set; }
    float duration;
    float timer;
    public bool isOn { get; private set; } = false;

    public event Action EndBuff;

    public Buff(EBuffType _type, float _duration)
    {
        Type = _type;
        duration = _duration;
        timer = _duration;
    }

    public void Start()
    {
        if (isOn) timer = duration;
        else isOn = true;
    }

    public void Update(float _deltaTime)
    {
        if (isOn) timer -= _deltaTime;
        if (timer <= 0.0f) End();
    }

    public void End()
    {
        isOn = false;
        EndBuff?.Invoke();
        EndBuff = null;
    }
}
