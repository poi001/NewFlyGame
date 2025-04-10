using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SkillUIStruct
{
    public Image skillBackGroundImage;
    public Image skillIconImage;
}


public class SkillUI : MonoBehaviour
{
    [Header("Skill UI")]
    [SerializeField] private SkillUIStruct[] skillImage;

    private int maxSkillNum;
    private int currentSkillNum;

    private PlayerCharacter player;
    private PlayerStatHandler stat;

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
        stat = player.statHandler;

        maxSkillNum = stat.GetMaxStat(EStatType.MP);
        currentSkillNum = maxSkillNum;

        for (int i = 0; i < maxSkillNum; i++) skillImage[i].skillBackGroundImage.gameObject.SetActive(true);
        ChangeImage(-1);
    }

    private void OnSubscribe()
    {
        stat.OnChangeStat += ChangedSkillPoint;
    }

    private void OffSubscribe()
    {
        stat.OnChangeStat -= ChangedSkillPoint;
    }

    private void ChangedSkillPoint()
    {
        currentSkillNum = stat.GetCurrentStat(EStatType.MP);

        ChangeImage(currentSkillNum);
    }

    private void ChangeImage(int _num)
    {
        _num = Mathf.Clamp(_num, -1, maxSkillNum);

        OnSkillIcon(_num);
    }

    private void OnSkillIcon(int _num)
    {
        for (int i = 0; i < maxSkillNum; i++)
        {
            if (i == _num - 1)
            {
                float gray_ = 120.0f / 255.0f;
                float white_ = 255.0f / 255.0f;
                float opaque = 255.0f / 255.0f;

                skillImage[i].skillBackGroundImage.color = new Color(gray_, gray_, gray_, opaque);
                skillImage[i].skillIconImage.color = new Color(white_, white_, white_, opaque);

                skillImage[i].skillBackGroundImage.transform.localScale = new Vector2(1.1f, 1.1f);
            }
            else
            {
                float gray_ = 120.0f / 255.0f;
                float white_ = 255.0f / 255.0f;
                float translucent = 75.0f / 255.0f;

                skillImage[i].skillBackGroundImage.color = new Color(gray_, gray_, gray_, translucent);
                skillImage[i].skillIconImage.color = new Color(white_, white_, white_, translucent);

                skillImage[i].skillBackGroundImage.transform.localScale = new Vector2(1.0f, 1.0f);
            }
        }
    }
}
