using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPopupWindow
{
    public void OnClickExit();
}

public class PopupBase : MonoBehaviour, IPopupWindow
{
    public void OnClickExit()
    {
        Destroy(gameObject);
    }
}
