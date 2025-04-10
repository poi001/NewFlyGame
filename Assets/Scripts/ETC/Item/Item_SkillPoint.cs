using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_SkillPoint : Item_Base
{
    private void Start()
    {
        if(itemType == EItemType.NULL) itemType = EItemType.SKILLPOINT;
        if (addStat == 0) addStat = 1;
    }

    public override void Ability(PlayerCharacter _player)
    {
        PlayerStatHandler _ps = _player.statHandler;
        int _curMP = _ps.GetCurrentStat(EStatType.MP);

        _ps.ChangeCurrentStat(EStatType.SPD, _curMP + 1);
        Delete();
    }
}
