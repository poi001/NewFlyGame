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
        // 에디터에서 실행 중일 때는 에디터가 종료됩니다.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // 실제 게임 실행 중일 때는 애플리케이션을 종료합니다.
            Application.Quit();
#endif
    }
}
