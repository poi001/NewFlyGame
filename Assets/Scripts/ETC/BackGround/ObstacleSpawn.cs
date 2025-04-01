using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private float goal;

    private float checkPointDistance;
    private int num = 0;

    private void Start()
    {
        checkPointDistance = goal / (obstacles.Length) / 2.0f;

        Instantiate(obstacles[num], gameObject.transform);
        num++;
    }

    private void Update()
    {
        // 게임 매니저에서 플레이어의 위치를 받아온다.
        float playerX = GameManager.Instance.Player.transform.position.x;

        //플레이어가 체크포인트에 도달하면 다음 장애물 타일들이 생성된다.
        if (checkPointDistance < playerX)
        {
            if (num < obstacles.Length)
            {
                Instantiate(obstacles[num], gameObject.transform);
                checkPointDistance += goal / (obstacles.Length);
                num++;
            }
        }
    }
}
