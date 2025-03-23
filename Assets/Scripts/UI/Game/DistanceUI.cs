using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceUI : MonoBehaviour
{
    [SerializeField] private Text distanceText;

    private void Update()
    {
        int _distance = (int)GameManager.Instance.Player.transform.position.x;
        distanceText.text = _distance.ToString() + "M";
    }
}
