using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyBala : MonoBehaviour
{
    void Start()
    {
        Invoke("DestruirBala", 5f);
    }

    void DestruirBala()
    {
        Destroy(this.gameObject);
    }
}