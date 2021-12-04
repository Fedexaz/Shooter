using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class progressBarEnemy : MonoBehaviour
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

        transform.localScale = new Vector3(Vida.GetComponentInParent<IAEnemigo>().VidaEnemigo * 0.8f * 0.01f, 0.2f, 0.05f);

        if (Vida.GetComponentInParent<IAEnemigo>().VidaEnemigo >= 50)
        {
            colorBarraVida.material.color = Color.green;
        }
        else if (Vida.GetComponentInParent<IAEnemigo>().VidaEnemigo <= 49)
        {
            colorBarraVida.material.color = Color.red;
        }
    }
}
