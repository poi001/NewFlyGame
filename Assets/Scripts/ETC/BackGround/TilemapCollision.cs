using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEditor.PlayerSettings;

public class TilemapCollision : MonoBehaviour
{
    //Ÿ�ϸ� ����.
    private Tilemap tilemap;

    private void Start()
    {
        tilemap = gameObject.GetComponent<Tilemap>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�±װ� �÷��̾����� �˻��Ѵ�.
        if(collision.gameObject.tag == DefineClass.Tag_Player)
        {
            //�浹 ������ ���� ��ǥ�� ��´�.
            Vector3 worldPosition = collision.transform.position;

            //���� ��ǥ�� Ÿ�ϸ��� �� ��ǥ�� ��ȯ�Ѵ�.
            Vector3Int tilePosition = tilemap.WorldToCell(worldPosition);

            //�浹 ���� �������� 8����� �浹 ������ Ÿ���� �����Ѵ�.
            DeleteTile(tilePosition);
        }
    }

    private void DeleteTile(Vector3Int _tilePosition)
    {
        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                Vector3Int pos = _tilePosition;
                pos.x += i;
                pos.y += j;
                tilemap.SetTile(pos, null);
            }
        }
    }
}
