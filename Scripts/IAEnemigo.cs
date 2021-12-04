using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAEnemigo : MonoBehaviour
{

    public ContadorEnemigos MotorJuego;

    public NavMeshAgent Agente;
    public GameObject Objetivo;
    public GameObject bala;
    public GameObject arma;

    GameObject balax;

    public bool EnemigoVivo = true;
    public bool Atacando = false;

    public float VidaEnemigo = 100;

    public Animator AnimacionesEnemigo;
    public AudioSource disparos;
    public AudioClip sonidoDisparo;

    float val = 1;

    private void Start()
    {
        Objetivo = GameObject.FindGameObjectWithTag("Player");
        MotorJuego = GameObject.FindGameObjectWithTag("MotorJuego").GetComponent<ContadorEnemigos>();
    }

    void Update()
    {
        if (VidaEnemigo <= 0)
        {
            VidaEnemigo = 0;
            MotorJuego.enemigosTotales-=1;
            Debug.Log("Enemigo asesinado");
            Destroy(gameObject);
        }

        if (EnemigoVivo)
        {
            transform.LookAt(Objetivo.transform.position);
            float dist = Vector3.Distance(transform.position, Objetivo.transform.position);

            if (dist >= 11)
            {
                Agente.destination = Objetivo.transform.position;

                if (Atacando)
                {
                    CancelInvoke("Shoot");
                    Atacando = false;
                }

                AnimacionesEnemigo.SetFloat("Caminando", 1);

            }

            if (dist <= 10)
            {
                if (val >= 0)
                {
                    val -= Time.deltaTime;
                    if (val <= 0f) val = 0;
                }

                AnimacionesEnemigo.SetFloat("Caminando", 0);
         
                Debug.Log("En rango de ataque");
                if(!Atacando)
                {
                    InvokeRepeating("Shoot", .5f, 1f);
                    Atacando = true;
                    Debug.Log("Disparando");
                }
            }
        }
    }

    public void Shoot()
    {
        balax = Instantiate(bala, new Vector3(arma.transform.position.x, arma.transform.position.y, arma.transform.position.z), new Quaternion());
        balax.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * 10, ForceMode.Impulse);
        //AnimacionesEnemigo.SetTrigger("Disparar");
        disparos.PlayOneShot(sonidoDisparo);
    }
}
