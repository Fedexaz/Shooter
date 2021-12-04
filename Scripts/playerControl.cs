using UnityEngine.UI;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerControl : MonoBehaviour
{
    float speedx;
    float speedz;

    public AudioSource disparos;
    public AudioClip sonidoDisparo;

    public float speed = 5f;
    public float rotationSpeed;
    public int VidaJugador = 100;

    public Text TextoVida;

    public GameObject bala;
    public GameObject arma;
    public GameObject MenuMuerte;
    public GameObject HUDJugador;

    public Animator Animaciones;

    GameObject balax;

    private void Start()
    {
        MenuMuerte.SetActive(false);
    }

    private void Update()
    {
        if(VidaJugador <= 0)
        {
            VidaJugador = 0;
            Debug.Log("Moriste");
            MenuMuerte.SetActive(true);
            HUDJugador.SetActive(false);
            return;
        }

        TextoVida.text = "Vida: " + VidaJugador;

        speedx = Gamepad.current.leftStick.x.ReadValue();
        speedz = Gamepad.current.leftStick.y.ReadValue();
        

        Animaciones.SetFloat("Caminando", speedz);

        //transform.Rotate(new Vector3(0f, speedx * Time.deltaTime * rotationSpeed, 0f), Space.Self);      
    }

    public void Shoot()
    {
        if (VidaJugador <= 0) return;
        balax = Instantiate(bala, new Vector3(arma.transform.position.x, arma.transform.position.y, arma.transform.position.z), new Quaternion());
        balax.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * 150, ForceMode.Impulse);
        //Animaciones.SetTrigger("Disparar");
        disparos.PlayOneShot(sonidoDisparo);
        Debug.Log("Disparo");
    }

}
