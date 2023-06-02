using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotaciondeCamara : MonoBehaviour

{
    //Variables

    private Vector2 Ang = new Vector2(-90 * Mathf.Deg2Rad, 0);
    public Transform follow;
    private bool vista = false;
    public Renderer[] followRender;
    public float distancia = 3f;
    public float sensibilidad = 1f;
    Vector3 offset = new Vector3(0,2,0);
    public AudioClip ad1, ad2;
    public AudioSource ads;
    public GameObject goJefe;
    public Jefe scJefe;

    // Start is called before the first frame update
    void Start()
    {

        //Bloqueo del puntero del mouse
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {

        //Obtencion de los angulos a los que se apunta
        float hor = Input.GetAxis("Mouse X");
        if (hor !=0)
        {
            Ang.x += hor * Mathf.Deg2Rad*sensibilidad;
        }
        float ver = Input.GetAxis("Mouse Y");
        if (ver != 0)
        {
            Ang.y += ver * Mathf.Deg2Rad*sensibilidad;
        }

        //Boton y variable del cambio de Perspectiva
        if (Input.GetMouseButtonUp(1)) {
            vista = !vista;
        }

        //Manejo de la musica del juego
        if (goJefe.activeSelf)
        {
            if (!ads.isPlaying)
            {
                ads.clip = ad1;
                ads.Play();
            }
            else
            {
                ads.clip = ad1;
            }
        }
        else if (scJefe.PS <= 0) {
            if (!ads.isPlaying)
            {
                ads.clip = ad2;
                ads.Play();
            }
            else
            {
                ads.clip = ad2;
            }
        }
        
        
        
        
    }
    // Update is called once per frame
    void LateUpdate()
    {
        //Calculos para la posicion de la camara respecto al jugador
        Vector3 orbit = new Vector3(
            Mathf.Cos(Ang.x) * Mathf.Cos(Ang.y),
            -Mathf.Sin(Ang.y) ,
            - Mathf.Sin(Ang.x) * Mathf.Cos(Ang.y)
             );

        float dist = distancia;
        RaycastHit hit;
        if(Physics.Raycast(follow.position+offset, orbit, out hit, distancia))
        {
            dist = (hit.point - follow.position).magnitude;
        }
        if (vista == false)
        {
            foreach (var r in followRender) {
                r.enabled = true;
            }
            
            transform.position = (follow.position + offset) + orbit * dist;
        }
        else {
            foreach (var r in followRender)
            {
                r.enabled = false;
            }
            transform.position = (follow.position + offset) + orbit*1;
        }


        //Rotacion de la camara hacia el Jugador    
        transform.rotation = Quaternion.LookRotation((follow.position+offset) - transform.position);
    }
}
