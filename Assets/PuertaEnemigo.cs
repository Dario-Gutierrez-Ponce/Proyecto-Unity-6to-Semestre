using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaEnemigo : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemigos;
    public Transform puerta;
    private Vector3 posini, posFin;
    void Start()
    {
        posini = puerta.position;
        posFin = puerta.position- new Vector3(0,20,0);
    }

    // Update is called once per frame
    void Update()
    {
        int contador = 0;
        for (int i = 0; i < enemigos.Length; ++i) {
            if (enemigos[i].activeSelf)
            {
                contador++;
            }
        }
        if (contador > 0)
        {
            if (posini.y > puerta.position.y)
            {
                puerta.Translate(new Vector3(0, 0.2f, 0));
            }
        }
        else
        {
            if (posFin.y < puerta.position.y)
            {
                puerta.Translate(new Vector3(0, -0.2f, 0));
            }
        }

    }
}
