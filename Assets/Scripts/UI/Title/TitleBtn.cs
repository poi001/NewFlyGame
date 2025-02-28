using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum EBtnType
{
    GAMESTART,
    RANK,
    OPTIONS,
    EXIT
}

public class TitleBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private EBtnType currentType;
    [SerializeField] private Transform btnScale;
    Vector3 defaultScale;

    private void Start()
    {
        defaultScale = btnScale.localScale;
    }

    public void OnBtnClick()
    {
        switch (currentType)
        {
            case EBtnType.GAMESTART:
                Debug.Log("GAMESTART");
                break;
            case EBtnType.RANK:
                Debug.Log("RANK");
                break;
            case EBtnType.OPTIONS:
                Debug.Log("OPTIONS");
                break;
            case EBtnType.EXIT:
                Debug.Log("EXIT");
                break;
            default:
                Debug.Log("default");
                break;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        btnScale.localScale = defaultScale * 1.2f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        btnScale.localScale = defaultScale;
    }
}
