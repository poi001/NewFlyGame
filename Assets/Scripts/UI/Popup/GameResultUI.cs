using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameResultUI : MonoBehaviour
{
    [SerializeField] private Text txt_Distance;
    [SerializeField] private Text txt_Timer;

    private void OnEnable()
    {
        string dis = ((int)GameManager.Instance.UIManager_.DistanceUI_.RecordDistance).ToString();
        string time = ((int)GameManager.Instance.UIManager_.DistanceUI_.RecordTime).ToString();

        txt_Distance.text = new string($"Record Distance: {dis}M");
        txt_Timer.text = new string($"Record Time: {time}sec");
    }

    public void OnClickMainMenu()
    {
        GameManager.Instance.SceneManagerManager__.ChangeScene(DefineClass.Scene_ManMenu);
    }

    public void OnClickExitGame()
    {
        // �����Ϳ��� ���� ���� ���� �����Ͱ� ����˴ϴ�.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // ���� ���� ���� ���� ���� ���ø����̼��� �����մϴ�.
            Application.Quit();
#endif
    }
}
