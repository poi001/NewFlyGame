using UnityEngine.SceneManagement;

public class SceneManager_
{
    public void ChangeScene(string _sceneName)
    {
        switch (_sceneName)
        {
            case DefineClass.Scene_ManMenu:
                {
                    SceneManager.LoadScene(DefineClass.Scene_ManMenu);
                    SoundManager.Instance.PlayBGM(SoundManager.EBGMType.BGM_TITLE);
                }
                break;

            case DefineClass.Scene_SelectCharacter:
                {
                    SceneManager.LoadScene(DefineClass.Scene_SelectCharacter);
                }
                break;

            case DefineClass.Scene_Stage1:
                {
                    SceneManager.LoadScene(DefineClass.Scene_Stage1);
                    SoundManager.Instance.PlayBGM(SoundManager.EBGMType.BGM_STAGE1);
                }
                break;

            default:
                break;
        }
    }
}
