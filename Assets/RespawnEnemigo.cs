using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnEnemigo : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemigos;
    private Vector3[] posenemigos = new Vector3[12];
    public Enemigo3[] scriptenemigo2;
    public Enemigo[] scriptenemigo;
    public VidaJugador vidajugador;
    void Start()
    {
        for (int i = 0; i < enemigos.Length; ++i) {
            posenemigos[i] = enemigos[i].transform.position;
            //scriptenemigo[i] = enemigos[i].GetComponent<Enemigo>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R)) {
                for (int i = 0; i < scriptenemigo.Length; ++i) {
                    scriptenemigo[i].PS = 4;
                }
                for (int i = 0; i < scriptenemigo2.Length; ++i)
                {
                    scriptenemigo2[i].PS = 2;
                }
                for (int i = 0; i < enemigos.Length; ++i) {
                    enemigos[i].SetActive(true);
                    enemigos[i].transform.position = posenemigos[i];
                    
                }
            }
        
    }
}
