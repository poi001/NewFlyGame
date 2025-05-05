using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

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
                    SceneManager.sceneLoaded += OnSceneLoaded_Stage1;
                    SceneManager.LoadScene(DefineClass.Scene_Stage1);
                    SoundManager.Instance.PlayBGM(SoundManager.EBGMType.BGM_STAGE1);
                }
                break;

            default:
                break;
        }
    }

    private void OnSceneLoaded_Stage1(Scene scene, LoadSceneMode mode)
    {
        GameManager.Instance.StartStage1();
        SceneManager.sceneLoaded -= OnSceneLoaded_Stage1;
    }
}
