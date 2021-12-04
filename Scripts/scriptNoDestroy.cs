using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptNoDestroy : MonoBehaviour
{
    void Start()
    {
        Screen.SetResolution(Mathf.CeilToInt(Screen.currentResolution.width * 0.5f), Mathf.CeilToInt(Screen.currentResolution.height * 0.5f), true);
        Invoke("AutoDelete", 1f);
    }

    void AutoDelete()
    {
        Destroy(gameObject);
    }

}
