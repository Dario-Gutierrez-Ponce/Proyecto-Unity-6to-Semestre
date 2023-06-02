using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil1 : MonoBehaviour
{
    // Start is called before the first frame update
    private bool cond = false;
    private bool col = false;
    private bool death = false;
    private float timer = 0;
    private float inc = 0;
    private Rigidbody rb;
    private Collider dispCol;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        dispCol = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (col == true) { 
            col = false;
            death = true;
            dispCol.enabled = false;
            
            timer = Time.time + 0.5f;
        }
        if (death == true) {
            inc += 0.2f;
            transform.localScale = new Vector3(inc,inc,inc);
            if (Time.time >= timer) {
                Destroy(gameObject);
            }
        }
        */
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null && cond == false) 
        {
            cond = true;
            Destroy(gameObject);
            //rb.velocity = Vector3.zero;
            //col = true;
        }
    }
}
