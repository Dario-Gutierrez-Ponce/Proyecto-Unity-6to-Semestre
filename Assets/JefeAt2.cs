using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class JefeAt2 : MonoBehaviour
{
    // Start is called before the first frame update
    public float cooldown = 1;
    private float timer = 0;
    public GameObject goDisparo;
    Quaternion currentRotation;
    public float velP = 30;
    public int fila = 0;
    void Start()
    {
        currentRotation.eulerAngles = new Vector3(90, 90, 90);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= Time.time)
        {
            timer = Time.time + cooldown;
            GameObject word1 = Instantiate(goDisparo, transform.position + new Vector3(2, -5, 0), transform.rotation) as GameObject;
            word1.GetComponent<Rigidbody>().velocity = (transform.position+ new Vector3(0,-60,0)).normalized * velP;
        }
    }
}
