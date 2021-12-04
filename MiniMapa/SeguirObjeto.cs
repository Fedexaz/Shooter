using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirObjeto : MonoBehaviour
{

    public Transform objetivo;

    void LateUpdate()
    {
        transform.position = new Vector3(objetivo.transform.position.x, 20, objetivo.transform.position.z);
    }
}
