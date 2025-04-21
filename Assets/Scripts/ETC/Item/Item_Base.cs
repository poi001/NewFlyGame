using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public enum EItemType
{
    NULL = 0,
    SPEEDUP = 1,
    SKILLPOINT = 2,
    SKILLPOINT_Max = 3,
    HPUP = 4
}

public interface IAbility
{
    public void Ability(PlayerCharacter _player);
    public void Delete();
}

public class Item_Base : MonoBehaviour, IAbility
{
    [SerializeField] protected EItemType itemType;
    [SerializeField] protected int addStat;

    protected PlayerCharacter player;
    protected ParticleSystem particle;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(DefineClass.Tag_Player))
        {
            if (collision.gameObject.TryGetComponent<PlayerCharacter>(out player)) Ability(player);
        }
    }

    public virtual void Ability(PlayerCharacter _player)
    {
        GameManager gm_ = GameManager.Instance;

        gm_.ActiveParticle(EParticleType.ITEM, gameObject.transform.position);
    }

    public void Delete()
    {
        Destroy(gameObject);
    }
}
