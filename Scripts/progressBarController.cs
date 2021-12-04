using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class progressBarController : MonoBehaviour
{

    public GameObject Vida;

    private Renderer colorBarraVida;

    void Start()
    {
        colorBarraVida = gameObject.GetComponent<Renderer>();
    }

    void Update()
    {
        transform.LookAt(Camera.main.transform.position);

        transform.localScale = new Vector3(Vida.GetComponentInParent<playerControl>().VidaJugador * 0.8f * 0.01f, 0.2f, 0.05f);

        if (Vida.GetComponentInParent<playerControl>().VidaJugador >= 50)
        {
            colorBarraVida.material.color = Color.green;
        }
        else if (Vida.GetComponentInParent<playerControl>().VidaJugador <= 49)
        {
            colorBarraVida.material.color = Color.red;
        }
    }
}