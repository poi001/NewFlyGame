using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] private Transform[] sprites;       // 배경 스프라이트 배열
    [SerializeField] private float halfSize;            // 배경 스프라이트 가로 길이의 절반
    private int spritesNum;                             // 배경 스프라이트 배열의 번호 ( 여기에서는 배경이 5개이므로 4가 된다 )

    private void Start()
    {
        spritesNum = sprites.Length - 1;
    }

    private void Update()
    {
        // 게임 매니저에서 플레이어의 위치를 받아온다.
        float playerX = GameManager.Instance.Player.transform.position.x;

        // 조건: 만약 5개 중에 4번째 배경에 다다르면
        if (sprites[spritesNum - 1].position.x - halfSize < playerX)
        {
            // 1번째 배경을 5번째로 옮기고 나머지 배경들을 하나씩 땡겨온다. 그리고 새로 배치된 5번째 배경의 위치를 조정한다.
            Transform temp = sprites[0];
            for (int i = 1; i < sprites.Length; i++) sprites[i - 1] = sprites[i];
            sprites[spritesNum] = temp;
            sprites[spritesNum].localPosition = sprites[spritesNum - 1].localPosition + (Vector3.right * halfSize * 2.0f);
        }
    }


}
