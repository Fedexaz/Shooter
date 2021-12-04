using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public Transform objetivo;

    void LateUpdate()
    {
        transform.position = new Vector3(objetivo.transform.position.x + 1, 4, objetivo.transform.position.z - 3.5f);
    }
}
