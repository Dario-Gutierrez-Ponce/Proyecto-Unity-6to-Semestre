using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaFinal : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject jefe;
    public Transform puerta;
    private Vector3 posini, posFin;
    void Start()
    {
        posini = puerta.position;
        posFin = puerta.position - new Vector3(0, 20, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (jefe.activeSelf) {
            if (posini.y > puerta.position.y)
            {
                puerta.Translate(new Vector3(0, 0.4f, 0));
            }
            
        }
        else
        {
            if (posFin.y < puerta.position.y)
            {
                puerta.Translate(new Vector3(0, -0.4f, 0));
            }
        }

    }
}
