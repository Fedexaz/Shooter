using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnEnemigos : MonoBehaviour
{
    public ContadorEnemigos ContadorEnemigos;
    public GameObject EnemigoPrefab;
    public Transform[] SpawnEnemigos;

    public Transform[] SpawnPickUps;
    public int PickupSpawned = 0;
    public GameObject PickUpPrefab;
    public int LastPickUpSpawn = -1;
    
    public GameObject HUDGame;

    public GameObject RondaWin;

    public int Ronda = 1;
    public float tiempoRonda = 0;
    public int EnemigosPorRonda = 0;
    public int EnemigoSpawneado = 0;

    void Start()
    {
        InvokeRepeating("SpawnEnemigo", .5f, .1f);
    }

    public void Update()
    {
        if (ContadorEnemigos.enemigosTotales > 0)
        {
            tiempoRonda += Time.deltaTime;
        }

        Debug.Log("Tiempo transcurrido: " + tiempoRonda);

        if(ContadorEnemigos.enemigosTotales == 0 && EnemigoSpawneado != 0)
        {
            EnemigoSpawneado = 0;

            int min = 0, seg = 0;
            min = (int)tiempoRonda / 60;
            seg = (int)tiempoRonda % 60;

            RondaWin.GetComponentInChildren<Text>().text = "¡Ronda " + Ronda + " completada!\nTiempo: " + min + " min " + seg + " seg \nPasando a la siguiente ronda en 5 segundos (Ronda " + (Ronda+1) + ")";
            RondaWin.SetActive(true);
            HUDGame.SetActive(false);

            Ronda += 1;
            tiempoRonda = 0;

            InvokeRepeating("SpawnEnemigo", 5f, .1f);
        }
    }

    void SpawnEnemigo()
    {
        if (Ronda > 1)
        { 
            HUDGame.SetActive(true);
            RondaWin.SetActive(false);
        }

        int spawn = Random.Range(0, SpawnEnemigos.Length);
        EnemigosPorRonda = Ronda * 2;

        if(EnemigoSpawneado < EnemigosPorRonda)
        {
            ContadorEnemigos.enemigosTotales++;
            EnemigoSpawneado++;
            Instantiate(EnemigoPrefab, SpawnEnemigos[spawn].position, Quaternion.Euler(0, 0, 0));   

            if(PickupSpawned == 0)
            {
                recalcularPickUp:
                
                int spawnPickUp = Random.Range(0, SpawnPickUps.Length);

                PickupSpawned = 1;
                
                if (spawnPickUp == LastPickUpSpawn)
                {
                    goto recalcularPickUp;
                }
                else
                {
                    LastPickUpSpawn = spawnPickUp;
                    Instantiate(PickUpPrefab, SpawnPickUps[spawnPickUp].position, Quaternion.Euler(0, 0, 0));
                }
            }
        }
        else
        {
            PickupSpawned = 0;
            CancelInvoke("SpawnEnemigo");
        }
    }
}
