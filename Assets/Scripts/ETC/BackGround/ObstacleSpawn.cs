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
        //�÷��̾ üũ����Ʈ�� �����ϸ� ���� ��ֹ� Ÿ�ϵ��� �����ȴ�.
        if (GameManager.Instance.Player != null)
        {
            if (checkPointDistance < GameManager.Instance.Player.transform.position.x)
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
}
