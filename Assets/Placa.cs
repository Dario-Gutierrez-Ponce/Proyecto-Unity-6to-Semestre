using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placa : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform ts;
    private Vector3 vctTsIn;
    private Vector3 vctTsOut;
    public MeshRenderer goLuz;
    public Material on;
    public Material off;
    public Material material;
    private bool enc = false;
    public bool direccion = false;
    public float movX = 0;
    public float movY = 0;
    public float movZ = 0;
    public float Vel = 0;

    void Start()
    {
        vctTsIn = ts.position;
        vctTsOut = ts.position+new Vector3(movX, movY, movZ);
        material = off;
        
    }

    // Update is called once per frame
    void Update()
    {
        goLuz.material = material;
        if (enc)
        {
            if (direccion == true)
            {
                if (vctTsOut.x > ts.position.x)
                {
                    ts.Translate(new Vector3(Vel, 0, 0));
                }
                if (vctTsOut.y > ts.position.y)
                {
                    ts.Translate(new Vector3(0, Vel, 0));
                }
                if (vctTsOut.z > ts.position.z)
                {
                    ts.Translate(new Vector3(0, 0, Vel));
                }
            }
            else
            {
                if (vctTsOut.x < ts.position.x)
                {
                    ts.Translate(new Vector3(-Vel, 0, 0));
                }
                if (vctTsOut.y < ts.position.y)
                {
                    ts.Translate(new Vector3(0, -Vel, 0));
                }
                if (vctTsOut.z < ts.position.z)
                {
                    ts.Translate(new Vector3(0, 0, -Vel));
                }
            }

        }
        else {
            if (direccion == true)
            {
                if (vctTsIn.x < ts.position.x)
                {
                    ts.Translate(new Vector3(-Vel, 0, 0));
                }
                if (vctTsIn.y < ts.position.y)
                {
                    ts.Translate(new Vector3(0, -Vel, 0));
                }
                if (vctTsIn.z < ts.position.z)
                {
                    ts.Translate(new Vector3(0, 0, -Vel));
                }
            }
            else
            {
                if (vctTsIn.x > ts.position.x)
                {
                    ts.Translate(new Vector3(Vel, 0, 0));
                }
                if (vctTsIn.y > ts.position.y)
                {
                    ts.Translate(new Vector3(0, Vel, 0));
                }
                if (vctTsIn.z > ts.position.z)
                {
                    ts.Translate(new Vector3(0, 0, Vel));
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        material = on;
        enc = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        material = off;
        enc = false;
    }
}
