using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_HPUp : Item_Base
{
    public override void Ability(PlayerCharacter _player)
    {
        base.Ability(player);

        PlayerStatHandler _ps = _player.statHandler;
        _ps.Healed();
        Delete();
    }
}
