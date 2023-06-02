using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class VidaJugador : MonoBehaviour
{
    public GameObject jugador;
    public GameObject explosion;
    public bool bexp = false;
    public int psMax = 3;
    public int psActual;
    public float cooldown = 1;
    private float cooldownTime = 0;
    public GameObject img;
    public GameObject[] vida = new GameObject[3];
    // Start is called before the first frame update
    void Start()
    {
        psActual = psMax;   
    }

    // Update is called once per frame
    void Update()
    {
        if (psActual <= 0)
        {
            img.SetActive(true);
            jugador.SetActive(false);
            if (bexp == false) {
                bexp = true;
            }
            
        }
        else { 
            //jugador.SetActive(true);
            img.SetActive (false);
            
        }
        for (int i = 0; i < vida.Length; i++)
            {
                if (i+1 == psActual)
                {
                    vida[i].SetActive(true);
                }
                else { 
                    vida[i].SetActive (false);
                }
            }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 13) {
            collision.transform.Translate(0, 0, -1);
            if (Time.time >= cooldownTime) { 
                GameObject word1 = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
                cooldownTime = Time.time+cooldown;
                psActual--;
                
            }
        }
    }
}
