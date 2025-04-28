using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager
{
    //Game UI [private]
    private HPUI hpUI;
    private DistanceUI distanceUI;
    private SkillUI skillUI;
    private TimerUI timerUI;

    //Popup UI [private]
    private GameResultUI gameResultUI;

    //Game UI [public]
    public HPUI HPUI_ { get { return hpUI; } private set { hpUI = value; } }
    public DistanceUI DistanceUI_ { get { return distanceUI; } private set { distanceUI = value; } }
    public SkillUI SkillUI_ { get { return skillUI; } private set { skillUI = value; } }
    public TimerUI TimerUI_ { get { return timerUI; } private set { timerUI = value; } }

    //Popup UI [public]
    public GameResultUI GameResultUI_ { get { return gameResultUI; } private set { gameResultUI = value; } }

    public void Init(GameObject _uiCanavas)
    {
        //Game UI
        _uiCanavas.transform.Find(DefineClass.UI_HP).TryGetComponent<HPUI>(out hpUI);
        _uiCanavas.transform.Find(DefineClass.UI_Distance).TryGetComponent<DistanceUI>(out distanceUI);
        _uiCanavas.transform.Find(DefineClass.UI_Skill).TryGetComponent<SkillUI>(out skillUI);
        _uiCanavas.transform.Find(DefineClass.UI_Timer).TryGetComponent<TimerUI>(out timerUI);

        //Popup UI
        _uiCanavas.transform.Find(DefineClass.UI_GameResult).TryGetComponent<GameResultUI>(out gameResultUI);
    }

    public void Destructor()
    {
        hpUI.gameObject.SetActive(false);
        distanceUI.gameObject.SetActive(false);
        skillUI.gameObject.SetActive(false);
        timerUI.gameObject.SetActive(false);
    }
}
