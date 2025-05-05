using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public enum ECharacterType
    {
        PIGEON = 0,
        CAT = 1,
        DOG = 2,
        RAT = 3
    }

    [SerializeField] private GameObject ToolTipObject;
    [SerializeField] private RectTransform btnScale;
    [SerializeField] private StatScriptableObject statSO;
    [SerializeField] private Text hpTxt;
    [SerializeField] private Text mpTxt;
    [SerializeField] private Text weightTxt;
    [SerializeField] private Text speedTxt;

    [SerializeField] private ECharacterType characterType;
    [SerializeField] private GameObject pigeonObject;
    [SerializeField] private GameObject catObject;
    [SerializeField] private GameObject dogObject;
    [SerializeField] private GameObject ratObject;

    Vector3 defaultScale;

    private void Start()
    {
        defaultScale = btnScale.localScale;

        SetText(statSO);
    }

    private void SetText(StatScriptableObject _so)
    {
        hpTxt.text = new string($"HP: {_so.maxHP.ToString()}");
        mpTxt.text = new string($"MP: {_so.maxMP.ToString()}");
        weightTxt.text = new string($"Weight: {_so.weight.ToString()}");
        speedTxt.text = new string($"MaxSpeed: {_so.maxSpeed.ToString()}");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        btnScale.localScale = defaultScale * 1.2f;
        SoundManager.Instance.PlaySFX(SoundManager.ESFXType.SFX_BTN, 1.0f, 2.0f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        btnScale.localScale = defaultScale;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (characterType)
        {
            case ECharacterType.PIGEON:
                GameManager.Instance.PlayerObject = pigeonObject;
                break;
            case ECharacterType.CAT:
                GameManager.Instance.PlayerObject = catObject;
                break;
            case ECharacterType.DOG:
                GameManager.Instance.PlayerObject = dogObject;
                break;
            case ECharacterType.RAT:
                GameManager.Instance.PlayerObject = ratObject;
                break;
            default:
                break;
        }

        GameManager.Instance.SceneManager__.ChangeScene(DefineClass.Scene_Stage1);
        //GameManager.Instance.StartStage1();
    }
}
