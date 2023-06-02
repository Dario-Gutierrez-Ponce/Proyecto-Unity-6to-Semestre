using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    [SerializeField] float velocidad = 0;
    [SerializeField] float tiempo = 0;
    [SerializeField] float tiempoInactivo = 0;
    [SerializeField] float direccion = 1f;
    [SerializeField] float x = 0f;
    [SerializeField] float y = 0f;
    [SerializeField] float z = 0f;
    float tmp = 0;
    float tmp2 = 0;
    // Start is called before the first frame update
    void Start()
    {
        tmp = tiempo;
        tmp2 = tiempo+tiempoInactivo;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time < tmp2)
        {
            if (Time.time < tmp) {
                transform.Translate(direccion * velocidad * x, direccion * velocidad * y, direccion * velocidad * z);
            }
        }
        else
        {
            direccion = -direccion;
            tmp += tiempo;
            tmp2 = tmp + tiempoInactivo;
        }

    }
}
