using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] private Transform[] sprites;       // ��� ��������Ʈ �迭
    [SerializeField] private float halfSize;            // ��� ��������Ʈ ���� ������ ����
    private int spritesNum;                             // ��� ��������Ʈ �迭�� ��ȣ ( ���⿡���� ����� 5���̹Ƿ� 4�� �ȴ� )

    private void Start()
    {
        spritesNum = sprites.Length - 1;
    }

    private void Update()
    {
        // ����: ���� 5�� �߿� 4��° ��濡 �ٴٸ���
        if(GameManager.Instance.Player != null)
        {
            if (sprites[spritesNum - 1].position.x - halfSize < GameManager.Instance.Player.transform.position.x)
            {
                // 1��° ����� 5��°�� �ű�� ������ ������ �ϳ��� ���ܿ´�. �׸��� ���� ��ġ�� 5��° ����� ��ġ�� �����Ѵ�.
                Transform temp = sprites[0];
                for (int i = 1; i < sprites.Length; i++) sprites[i - 1] = sprites[i];
                sprites[spritesNum] = temp;
                sprites[spritesNum].localPosition = sprites[spritesNum - 1].localPosition + (Vector3.right * halfSize * 2.0f);
            }
        }
    }


}
