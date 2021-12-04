using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("COliSION");

        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<playerControl>().VidaJugador += 20;
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, - 40 * Time.deltaTime, 0));
    }
}
