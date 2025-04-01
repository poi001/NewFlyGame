using System.Collections;
using UnityEngine;

public class MotionTrail : MonoBehaviour
{
    [SerializeField]private GameObject ghost;           // ÀÜ»ó ÀÌ¹ÌÁö

    private float ghostDelay = 0.1f;                    // ÀÜ»ó µô·¹ÀÌ
    private float timeBasket;                           // ½Ã°£À» Àê ¶§, »ç¿ëÇÒ º¯¼ö
    private bool isMakeGhost;                           // ÀÜ»ó On/Off ¿©ºÎ

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
