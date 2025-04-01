using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkill
{
    public void Init(PlayerCharacter _player);
    public void ActiveSkill();
    public void DeactiveSkill();
}

public abstract class SkillBase : ISkill
{
    protected PlayerCharacter character;
    public float time { get; protected set; }
    protected Buff buff;

    public void Init(PlayerCharacter _player)
    {
        character = _player;
    }

    public abstract void ActiveSkill();

    public abstract void DeactiveSkill();

    protected void CreateBuff(EBuffType _buffType, float _time)
    {
        buff = new Buff(_buffType, _time);
        character.skillHandler.buffSystem.AddBuff(buff);
        buff.EndBuff += DeactiveSkill;
    }
}
