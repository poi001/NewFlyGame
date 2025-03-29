using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    [field: SerializeField] public Text TimerText { get; private set; }
    public float Time_ { get; private set; }

    private void Start()
    {
        TimerText = GetComponent<Text>();
    }

    private void Update()
    {
        Time_ += Time.deltaTime;
        int time_int = (int)Time_;

        TimerText.text = time_int.ToString();
    }
}
