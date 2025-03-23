using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    //[SerializeField] private Text timerText;
    private float time_;
    public Text timerText;
    private void Update()
    {
        time_ += Time.deltaTime;
        int time_int = (int)time_;

        timerText.text = time_int.ToString();
    }
}
