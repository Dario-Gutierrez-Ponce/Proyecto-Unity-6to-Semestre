using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Enemigo : MonoBehaviour
{

    public float rangoDeAlerta;
    public LayerMask capaDelJugador;
    public Vector3 fix = new Vector3 (0.0f, 5f, 0.0f);
    public Transform jugador;
    public GameObject Hit;
    public int PS = 2;
    bool estarAlerta;
    public float velocidad;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        estarAlerta = Physics.CheckSphere(transform.position,rangoDeAlerta ,capaDelJugador);
        if(estarAlerta == true)
        {
            Vector3 posJugador = new Vector3(jugador.position.x, transform.position.y, jugador.position.z);
            transform.LookAt(posJugador);
            transform.position = Vector3.MoveTowards(transform.position, posJugador, velocidad * Time.deltaTime);
        }
        if (PS <= 0) {
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
        if (collision.gameObject.layer == 9) {
            GameObject word1 = Instantiate(Hit, transform.position+fix, Quaternion.identity) as GameObject;
            PS--;
        }
    }
}
