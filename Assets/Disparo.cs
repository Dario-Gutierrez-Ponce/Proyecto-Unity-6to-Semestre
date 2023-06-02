using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public float cooldown = 1f;
    float timer = 0f;
    public bool disparo = false;
    bool arrojar = false;
    public Animator animator;
    public GameObject goDisparo;
    public Transform trBrazo;
    public Camera camara;
    private Vector3 destino;
    public float velocidad = 10;
    Vector3 fix = new Vector3 (0f, -2f, 0f);
    private Vector2 Ang = new Vector2(-90 * Mathf.Deg2Rad, 0);


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (timer <= Time.time)
        {
            Debug.Log("Disparo");
            disparo = false;
            if (arrojar == true) {
                Ray ray = camara.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    destino = ray.GetPoint(1000);
                    //destino = hit.point;
                }
                else { 
                    destino = ray.GetPoint(1000);
                }


                float hor = Input.GetAxis("Mouse X");
                if (hor != 0)
                {
                    Ang.x += hor * Mathf.Deg2Rad * 3;
                }
                float ver = Input.GetAxis("Mouse Y");
                if (ver != 0)
                {
                    Ang.y += ver * Mathf.Deg2Rad * 3;
                }
                Vector3 orbit = new Vector3(
                    Mathf.Cos(Ang.x) * Mathf.Cos(Ang.y),
                    -Mathf.Sin(Ang.y),
                    -Mathf.Sin(Ang.x) * Mathf.Cos(Ang.y)
                );



                GameObject word1 = Instantiate(goDisparo, trBrazo.position + fix , Quaternion.identity) as GameObject;
                word1.GetComponent<Rigidbody>().velocity = (destino - (trBrazo.position + fix)).normalized * velocidad;

                arrojar = false;
            }
            if (Input.GetAxisRaw("Fire1") == 1)
            {
                //disparo = true;
                //GameObject word1 = Instantiate(goDisparo, trBrazo.position + fix, Quaternion.identity) as GameObject;
                arrojar = true;
                timer = Time.time + cooldown;
            }
        }
        else { 
            disparo = true;
            Debug.Log("Espera");
            
        }
    }
}
