using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResultUI : PopupBase
{
    public void OnClickMainMenu()
    {

    }

    public void OnClickGameExit()
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
