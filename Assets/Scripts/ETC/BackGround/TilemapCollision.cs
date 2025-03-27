using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEditor.PlayerSettings;

public class TilemapCollision : MonoBehaviour
{
    //타일맵 정보.
    private Tilemap tilemap;

    private void Start()
    {
        tilemap = gameObject.GetComponent<Tilemap>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //태그가 플레이어인지 검사한다.
        if(collision.gameObject.tag == DefineClass.Tag_Player)
        {
            //충돌 지점의 월드 좌표를 얻는다.
            Vector3 worldPosition = collision.transform.position;

            //월드 좌표를 타일맵의 셀 좌표로 변환한다.
            Vector3Int tilePosition = tilemap.WorldToCell(worldPosition);

            //충돌 지점 기준으로 8방향과 충돌 지점의 타일을 삭제한다.
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
