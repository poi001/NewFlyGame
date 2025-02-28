using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    float y;

    private void Start()
    {
        y = gameObject.transform.position.y;
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.Player != null)
        {
            Vector3 _playerPos = GameManager.Instance.Player.gameObject.transform.localPosition;
            gameObject.transform.position = new Vector3(_playerPos.x, y, -10.0f);
        }
        else Debug.LogError("GameManager.Instance.Player == null, PlayerCamera -> FixedUpdate");
    }
}
