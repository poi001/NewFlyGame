using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_SpeedUp : Item_Base
{
    private void Start()
    {
        if (itemType == EItemType.NULL) itemType = EItemType.SPEEDUP;
        if (addStat == 0) addStat = 1;
    }

    public override void Ability(PlayerCharacter _player)
    {
        base.Ability(player);

        PlayerStatHandler _ps = _player.statHandler;
        int _curSPD = _ps.GetCurrentStat(EStatType.SPD);

        _ps.ChangeCurrentStat(EStatType.SPD, _curSPD + addStat);
        Delete();
    }
}
