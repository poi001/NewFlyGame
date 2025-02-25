using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_SkillPointMax : Item_Base
{
    private void Start()
    {
        if (itemType == EItemType.NULL) itemType = EItemType.SKILLPOINT_Max;
        if (addStat == 0) addStat = 9;
    }

    public override void Ability(PlayerCharacter _player)
    {
        _player.statHandler.statData.mp.current = _player.statHandler.statData.mp.max;
        Delete();
    }
}
