using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaJefe : MonoBehaviour
{
    // Start is called before the first frame update
    public int vertical = 0;
    public int horizontal = 0;
    public GameObject jefe;
    public Material m1, m2, m3;
    private float cooldown1 = 0.5f; 
    private Jefe scJefe;
    private float timer = 0;
    public MeshRenderer mRenderer;
    void Start()

    {
        scJefe = jefe.GetComponent<Jefe>();
        //mRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jefe.activeSelf) { 
            if(scJefe.nataque != 3)
            {
                if (timer < Time.time) { 
                    timer = Time.time+ cooldown1;
                    int material = Random.Range(0, 3);
                    switch (material) { 
                        case 0:
                            mRenderer.material = m1;
                            break;
                        case 1:
                            mRenderer.material = m2;
                            break;
                        case 2:
                            mRenderer.material = m3;
                            break;
                        case 3:
                            mRenderer.material = m3;
                        break;
                    }
                }
            }
            else
            {
                if(horizontal - 1 == scJefe.fila)
                {
                    mRenderer.material = m2;
                }
                else
                {
                    mRenderer.material = m3;
                }
            }
        }
    }
}
