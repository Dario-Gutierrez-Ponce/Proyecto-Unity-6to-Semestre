using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Start is called before the first frame update
    public bool activo = false;
    //public GameObject[] goCheckpoints;
    public GameObject jugador;
    public GameObject jefe;
    public Jefe scriptjefe;
    public CharacterController characterController;
    public Transform tsJugador;
    public Checkpoint[] checkpoints;
    public VidaJugador vidajugador;
    public Material on;
    public Material off;
    private MeshRenderer mat;
    public bool checkpointfinal = false;
    void Start()
    {
        //for (int i = 0; i < goCheckpoints.Length; ++i) {
        //    checkpoints[i] = goCheckpoints[i].GetComponent<Checkpoint>();
        //}
        mat = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (activo)
        {
            if (Input.GetKeyUp(KeyCode.R))
            {
                vidajugador.psActual = vidajugador.psMax;
                jugador.SetActive(true);
                characterController.enabled = false;
                tsJugador.position = transform.position;
                characterController.enabled = true;
                if (checkpointfinal) { 
                    scriptjefe.nataque = 0;
                    scriptjefe.PS = 25;
                    jefe.SetActive(true);
                }
                
                
            }
            mat.material = on;
        }
        else { 
            mat.material = off;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (var item in checkpoints)
        {
            item.activo = false;
        }
        
        if (!activo) { 
            if (checkpointfinal == true) { 
                jefe.SetActive(true);
                scriptjefe.PS = 25;
                vidajugador.psActual = vidajugador.psMax;
                jugador.SetActive(true);
                characterController.enabled = false;
                tsJugador.position = transform.position;
                characterController.enabled = true;
            }
        }
        activo = true;
        
    }
}
