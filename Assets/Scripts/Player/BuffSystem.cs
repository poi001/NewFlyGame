using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSystem
{
    List<Buff> buffList = new List<Buff>();

    public void AddBuff(Buff _buff)
    {
        //이미 있는 버프이면 지속시간만 초기화한다.
        foreach (Buff item in buffList)
        {
            if(item.Type == _buff.Type)
            {
                item.Start();
                return;
            }
        }

        buffList.Add(_buff);
        buffList[buffList.Count - 1].Start();
    }

    public void Update(float _deltaTime)
    {
        for (int i = 0; i < buffList.Count; ++i)
        {
            buffList[i].Update(_deltaTime);

            if (!buffList[i].isOn)
            {
                buffList.RemoveAt(i);
            }
        }
    }

    public List<Buff> GetBuffList()
    {
        return buffList;
    }
}
