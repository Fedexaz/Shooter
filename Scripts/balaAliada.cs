using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balaAliada : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bala aliada Impactada");
        if (other.gameObject.tag == "Enemigo")
        {
            other.gameObject.GetComponent<IAEnemigo>().VidaEnemigo -= 20;
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Entorno")
        {
            Destroy(gameObject);
        }
    }
}
