using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemigo3 : MonoBehaviour
{
    public float rangoDeAlerta;
    public LayerMask capaDelJugador;
    public Vector3 fix = new Vector3(0.0f, 5f, 0.0f);
    public Transform jugador;
    public GameObject Hit;
    public int PS = 2;
    bool estarAlerta;
    public GameObject goDisparo;
    public float velocidad = 1;
    public float velP = 30;
    public float cooldown = 1;
    private float timer = 0;


    //Vector3 currentEulerAngles;
    Quaternion currentRotation;

    /*
    public float cooldown = 1f;
    float timer = 0f;
    public bool disparo = false;
    bool arrojar = false;
    public Animator animator;
    
    public Transform trEnemigo;
    private Vector3 destino;
    public float velocidad = 10;
    //Vector3 fix = new Vector3(0f, -2f, 0f);
    private Vector2 Ang = new Vector2(-90 * Mathf.Deg2Rad, 0);*/


    void Start()
    {
        //transform.Rotate(new Vector3(90,0,0));
        currentRotation.eulerAngles = new Vector3 (0, -40, 0);
    }

    // Update is called once per frame
    void Update()
    {

        estarAlerta = Physics.CheckSphere(transform.position, rangoDeAlerta, capaDelJugador);
        if (estarAlerta == true)
        {
            Vector3 posJugador = new Vector3(jugador.position.x, transform.position.y, jugador.position.z);
            //transform.LookAt(posJugador);
            //transform.position = Vector3.MoveTowards(transform.position, posJugador, velocidad * Time.deltaTime);
            Vector3 targetDirection = jugador.position - transform.position;

            // The step size is equal to speed times frame time.
            float singleStep = velocidad * Time.deltaTime;

            // Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

            // Draw a ray pointing at our target in
            Debug.DrawRay(transform.position, newDirection, Color.red);

            // Calculate a rotation a step closer to the target and applies rotation to this object
            transform.rotation = Quaternion.LookRotation(newDirection);
            if (timer <= Time.time)
            {
                timer = Time.time + cooldown;
                GameObject word1 = Instantiate(goDisparo, transform.position + new Vector3(0, -5, 0), transform.rotation * currentRotation) as GameObject;
                word1.GetComponent<Rigidbody>().velocity = (jugador.position - transform.position + new Vector3(0, 1, 0)).normalized * velP;
            }
        
        }
        if (PS <= 0)
        {
            gameObject.SetActive(false);
        }

        
    }
    private void onDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoDeAlerta);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9)
        {
            GameObject word1 = Instantiate(Hit, transform.position + fix, Quaternion.identity) as GameObject;
            PS--;
        }
    }
}
