using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceUI : MonoBehaviour
{
    [field: SerializeField] public Text DistanceText {  get; private set; }
    public float RecordDistance { get; private set; }
    public float RecordTime { get; private set; }

    private void Start()
    {
        DistanceText = GetComponent<Text>();
    }

    private void Update()
    {
        float x = GameManager.Instance.Player.transform.position.x;

        int _distance = (int)x;
        DistanceText.text = _distance.ToString() + "M";

        if (RecordDistance < x)
        {
            RecordDistance = x;
            RecordTime = GameManager.Instance.UIManager_.TimerUI_.Time_;
        }
    }
}
