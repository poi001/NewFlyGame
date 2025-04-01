using System.Collections;
using UnityEngine;

public class MotionTrail : MonoBehaviour
{
    [SerializeField]private GameObject ghost;           // �ܻ� �̹���

    private float ghostDelay = 0.1f;                    // �ܻ� ������
    private float timeBasket;                           // �ð��� �� ��, ����� ����
    private bool isMakeGhost;                           // �ܻ� On/Off ����

    void FixedUpdate()
    {
        if (isMakeGhost)
        {
            if (timeBasket > 0)
            {
                timeBasket -= Time.deltaTime;
            }
            else
            {
                GameObject currentGhost = Instantiate(ghost, transform.position, transform.rotation);
                Sprite currentSprite =  GetComponent<SpriteRenderer>().sprite;
                currentGhost.transform.localScale = transform.localScale;
                currentGhost.GetComponent<SpriteRenderer>().sprite = currentSprite;
                currentGhost.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
                timeBasket = ghostDelay;
                Destroy(currentGhost, 0.25f);
            }
        }
    }

    //delay setting
    public void OnMotionTrail(float _time, float _delay)
    {
        ghostDelay = _delay;
        timeBasket = ghostDelay;
        isMakeGhost = true;

        StartCoroutine(OffMotionTrail_Coroutine(_time));
    }
    //No delay setting
    public void OnMotionTrail(float _time)
    {
        timeBasket = ghostDelay;
        isMakeGhost = true;

        StartCoroutine(OffMotionTrail_Coroutine(_time));
    }

    public void OffMotionTrail()
    {
        isMakeGhost = false;
    }

    IEnumerator OffMotionTrail_Coroutine(float _time)
    {
        yield return new WaitForSeconds(_time);
        OffMotionTrail();
    }
}
