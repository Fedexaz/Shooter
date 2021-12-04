using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorEnemigos : MonoBehaviour
{
    public Text textContadorEnemigos;

    public int enemigosTotales = 0;

    public void Update()
    {
        textContadorEnemigos.text = "Enemigos restantes: " + enemigosTotales;
    }
}
