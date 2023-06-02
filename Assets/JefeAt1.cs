using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class JefeAt1 : MonoBehaviour
{
    // Start is called before the first frame update
    public float rangoDeAlerta;
    public LayerMask capaDelJugador;
    public Vector3 fix = new Vector3(0.0f, 5f, 0.0f);
    public Transform jugador;
    public GameObject goDisparo;
    public float velocidad = 1;
    public float velP = 30;
    public float cooldown = 1;
    private float timer = 0;
    Quaternion currentRotation;
    void Start()
    {
        currentRotation.eulerAngles = new Vector3(0, -40, 0);
    }

    // Update is called once per frame
    void Update()
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

        transform.rotation = Quaternion.LookRotation(newDirection);
        if (timer <= Time.time)
        {
            timer = Time.time + cooldown;
            GameObject word1 = Instantiate(goDisparo, transform.position + new Vector3(0, -5, 0), transform.rotation * currentRotation) as GameObject;
            word1.GetComponent<Rigidbody>().velocity = (jugador.position - transform.position + new Vector3(0, 1, 0)).normalized * velP;
        }
    }
}
