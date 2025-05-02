using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXCanavas : MonoBehaviour
{
    [SerializeField] private GameObject Sprint;
    [SerializeField] private GameObject WeightDown;
    [SerializeField] private GameObject SpeedUp;
    [SerializeField] private GameObject Heal;
    [SerializeField] private GameObject Armor;
    [SerializeField] private GameObject Shield;

    private void Update()
    {

    }

    public void OnPlayOneShot(EVFXType _type)
    {

    }

    public void OnPlay(EVFXType _type)
    {
        switch (_type)
        {
            case EVFXType.SPRINT:
                {
                    Sprint.SetActive(true);
                }
                break;

            case EVFXType.WEIGHTDOWN:
                {
                    WeightDown.SetActive(true);
                }
                break;

            case EVFXType.SPEEDUP:
                {
                    SpeedUp.SetActive(true);
                }
                break;

            case EVFXType.HEAL:
                {
                    Heal.SetActive(true);
                }
                break;

            case EVFXType.ARMOR:
                {
                    Armor.SetActive(true);
                }
                break;

            case EVFXType.SHIELD:
                {
                    Shield.SetActive(true);
                }
                break;

            default:
                break;
        }
    }

    public void OffPlay(EVFXType _type)
    {
        switch (_type)
        {
            case EVFXType.SPRINT:
                {
                    Sprint.SetActive(false);
                }
                break;

            case EVFXType.WEIGHTDOWN:
                {
                    WeightDown.SetActive(false);
                }
                break;

            case EVFXType.SPEEDUP:
                {
                    SpeedUp.SetActive(false);
                }
                break;

            case EVFXType.HEAL:
                {
                    Heal.SetActive(false);
                }
                break;

            case EVFXType.ARMOR:
                {
                    Armor.SetActive(false);
                }
                break;

            case EVFXType.SHIELD:
                {
                    Shield.SetActive(false);
                }
                break;

            default:
                break;
        }
    }
}
