using UnityEngine;
using UnityEngine.UI;

public class HPUI : MonoBehaviour
{
    [Header("HP UI")]
    [SerializeField] private Image[] hpImage;

    [Header("Sprite")]
    [SerializeField] private Sprite fullHPSprite;
    [SerializeField] private Sprite emptyHPSprite;

    private int maxHP;
    private int currentHP;

    private PlayerCharacter player;

    private void Start()
    {
        Init();

        OnSubscribe();
    }

    private void OnDisable()
    {
        OffSubscribe();
    }

    private void Init()
    {
        player = GameManager.Instance.Player;

        maxHP = player.statHandler.statData.hp.max;
        currentHP = maxHP;

        for (int i = 0; i < maxHP; i++) hpImage[i].gameObject.SetActive(true);
        ChangeImage(maxHP);
    }

    private void OnSubscribe()
    {
        player.statHandler.OnDamage += Damaged;
        player.statHandler.OnHeal += Healed;
    }

    private void OffSubscribe()
    {
        player.statHandler.OnDamage -= Damaged;
        player.statHandler.OnHeal -= Healed;
    }

    private void Damaged()
    {
        currentHP = Mathf.Clamp(currentHP - 1, 0, maxHP);

        ChangeImage(currentHP);
    }

    private void Healed()
    {
        currentHP = Mathf.Clamp(currentHP + 1, 0, maxHP);

        ChangeImage(currentHP);
    }

    private void ChangeImage(int _num)
    {
        for (int i = 0; i < maxHP; i++)
        {
            if (i < _num) hpImage[i].sprite = fullHPSprite;
            else hpImage[i].sprite = emptyHPSprite;
        }
    }
}
