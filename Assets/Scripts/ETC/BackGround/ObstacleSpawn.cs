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
        // ���� �Ŵ������� �÷��̾��� ��ġ�� �޾ƿ´�.
        float playerX = GameManager.Instance.Player.transform.position.x;

        //�÷��̾ üũ����Ʈ�� �����ϸ� ���� ��ֹ� Ÿ�ϵ��� �����ȴ�.
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
