using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balaEnemiga : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bala enemiga Impactada");
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<playerControl>().VidaJugador -= 10;
            Destroy(gameObject);
        }
        
        if (other.gameObject.tag == "Entorno")
        {
            Destroy(gameObject);
        }
    }
}
