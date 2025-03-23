using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    private HPUI hpUI;
    private DistanceUI distanceUI;
    private SkillUI skillUI;
    private TimerUI timerUI;

    public HPUI HPUI_ { get { return hpUI; } private set { hpUI = value; } }
    public DistanceUI DistanceUI_ { get { return distanceUI; } private set { distanceUI = value; } }
    public SkillUI SkillUI_ { get { return skillUI; } private set { skillUI = value; } }
    public TimerUI TimerUI_ { get { return timerUI; } private set { timerUI = value; } }

    public void Init(GameObject _uiCanavas)
    {
        _uiCanavas.transform.Find(DefineClass.UI_HP).TryGetComponent<HPUI>(out hpUI);
        _uiCanavas.transform.Find(DefineClass.UI_Distance).TryGetComponent<DistanceUI>(out distanceUI);
        _uiCanavas.transform.Find(DefineClass.UI_Skill).TryGetComponent<SkillUI>(out skillUI);
        _uiCanavas.transform.Find(DefineClass.UI_Timer).TryGetComponent<TimerUI>(out timerUI);
    }
}
