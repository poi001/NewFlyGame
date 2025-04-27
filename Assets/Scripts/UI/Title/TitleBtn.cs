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
        SoundManager.Instance.PlaySFX(SoundManager.ESFXType.SFX_BTN, 1.0f, 1.5f);

        switch (currentType)
        {
            case EBtnType.GAMESTART:
                Debug.Log("GAMESTART");
                break;

            case EBtnType.RANK:
                Debug.Log("RANK");
                break;

            case EBtnType.OPTIONS:
                Instantiate(GameManager.Instance.OptionsUICanavas, Vector2.zero, Quaternion.identity);
                break;

            case EBtnType.EXIT:
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
            // 실제 게임 실행 중일 때는 애플리케이션을 종료합니다.
            Application.Quit();
#endif
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
