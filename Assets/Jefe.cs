using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.Rendering;

public class Jefe : MonoBehaviour
{
    // Start is called before the first frame update
    //public bool ataque = false;
    public int nataque = 0;
    public int PS = 25;
    
    public GameObject at11, at12;
    public GameObject at211, at212, at221, at222, at231, at232, at241, at242, at251, at252;
    public GameObject at31, at32;
    private Vector3 pos1, pos2;
    public Enemigo scat31;
    public Enemigo3 scat32;
    public float cooldown = 5.0f;
    private float timer = 0;
    public int fila;
    void Start()
    {
        timer = Time.time+cooldown;
        pos1 = at31.transform.position;
        pos2 = at32.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < Time.time) {
            timer = Time.time + cooldown;
            nataque++;
            if(nataque > 5)
            {
                nataque = 0;
            }

            if (nataque == 2 || nataque == 4)
            {
                at11.SetActive(false);
                at12.SetActive(false);
                at211.SetActive(false);
                at212.SetActive(false);
                at221.SetActive(false);
                at222.SetActive(false);
                at231.SetActive(false);
                at232.SetActive(false);
                at241.SetActive(false);
                at242.SetActive(false);
                at251.SetActive(false);
                at252.SetActive(false);
            }

            if (nataque == 1) {
                at11.SetActive(true);
                at12.SetActive(true);
            }

            if (nataque == 3)
            {
                fila = Random.Range(0, 5);
                switch (fila)
                {
                    case 0:
                        at221.SetActive(true);
                        at222.SetActive(true);
                        at231.SetActive(true);
                        at232.SetActive(true);
                        at241.SetActive(true);
                        at242.SetActive(true);
                        at251.SetActive(true);
                        at252.SetActive(true);
                        break;
                    case 1:
                        at211.SetActive(true);
                        at212.SetActive(true);
                        at231.SetActive(true);
                        at232.SetActive(true);
                        at241.SetActive(true);
                        at242.SetActive(true);
                        at251.SetActive(true);
                        at252.SetActive(true);
                        break;
                    case 2:
                        at221.SetActive(true);
                        at222.SetActive(true);
                        at211.SetActive(true);
                        at212.SetActive(true);
                        at241.SetActive(true);
                        at242.SetActive(true);
                        at251.SetActive(true);
                        at252.SetActive(true);
                        break;
                    case 3:
                        at221.SetActive(true);
                        at222.SetActive(true);
                        at231.SetActive(true);
                        at232.SetActive(true);
                        at211.SetActive(true);
                        at212.SetActive(true);
                        at251.SetActive(true);
                        at252.SetActive(true);
                        break;
                    case 4:
                        at221.SetActive(true);
                        at222.SetActive(true);
                        at231.SetActive(true);
                        at232.SetActive(true);
                        at241.SetActive(true);
                        at242.SetActive(true);
                        at211.SetActive(true);
                        at212.SetActive(true);
                        break;
                    case 5:
                        at221.SetActive(true);
                        at222.SetActive(true);
                        at231.SetActive(true);
                        at232.SetActive(true);
                        at241.SetActive(true);
                        at242.SetActive(true);
                        at211.SetActive(true);
                        at212.SetActive(true);
                        break;
                }
            }

            if (nataque == 5)
            {
                at31.SetActive(false);
                at32.SetActive(false);
                int en = Random.Range(0, 3);
                switch (en)
                {
                    case 0:
                        scat31.PS = 2;
                        at31.SetActive(true);
                        break; 
                    case 1:
                        scat32.PS = 1;
                        at32.SetActive(true);
                        break;
                    case 2:
                        scat32.PS = 1;
                        at32.SetActive(true);
                        break;
                }
            }

        }
        if (PS <= 0)
        {
            at11.SetActive(false);
            at12.SetActive(false);
            at211.SetActive(false);
            at212.SetActive(false);
            at221.SetActive(false);
            at222.SetActive(false);
            at231.SetActive(false);
            at232.SetActive(false);
            at241.SetActive(false);
            at242.SetActive(false);
            at251.SetActive(false);
            at252.SetActive(false);
            gameObject.SetActive(false);

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9)
        {
            //GameObject word1 = Instantiate(Hit, transform.position + fix, Quaternion.identity) as GameObject;
            PS--;
        }
    }
}
