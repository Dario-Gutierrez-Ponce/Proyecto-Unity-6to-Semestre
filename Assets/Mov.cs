using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class Mov : MonoBehaviour
{


    //Variables

    private Disparo vardisparo;
    public GameObject obj;

    [SerializeField] float velocidad = 3f;
    Rigidbody rb;
    public Animator animator;
    public Transform cam;
    private CharacterController characterController;

    public float m_Thrust = 20f;
    
    public float gravedad = 9.81f;
    public float Vcaida = 1f;
    public float Fsalto = 1f;





    Vector3 m_EulerAngleVelocity;


    void Start()

    {
        //Asignacion de componentes a las variables locales

        vardisparo = obj.GetComponent<Disparo>();

        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody>();

        characterController = GetComponent<CharacterController>();

        m_EulerAngleVelocity = new Vector3(0, 100, 0);
    }



    // Update is called once per frame

    void Update()

    {
        //Deteccion Suavizada de los controles de movimiento

        float moverX = Input.GetAxis("Horizontal") * Time.deltaTime * velocidad;

        float moverZ = Input.GetAxis("Vertical") * Time.deltaTime * velocidad;

        int yy, inf = 0;
        float may = 0;


        //Asignacion de enteros conforme el control del eje vertical

        if (Input.GetAxis("Vertical") >= 0)
        {
            yy = 1;
            may = 0;
        }
        else
        {
            yy = -1;
            may = 1;
        }
        
        
        //Variable de transformacion

        Vector3 Vm = Vector3.zero;


        
        
        //Simulacion de gravedad en el CharacterController y Boton de salto

        if (characterController.isGrounded)
        {
            Vcaida = -gravedad * Time.deltaTime;
            Vm.y = Vcaida;
            if (Input.GetButton("Jump"))
            {
                Vcaida = Fsalto;
                Vm.y = Vcaida;
            }
        }
        else 
        {
            Vcaida -= gravedad * Time.deltaTime;
            Vm.y = Vcaida;
        }


        //Movimiento del personaje
        
        if(Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
        {
            inf = 0;
            if(vardisparo.disparo == false)
                characterController.Move(transform.up * velocidad * Time.deltaTime + Vm);
            else
                characterController.Move(Vm);
        }
        else
        {
            inf = 1;
            characterController.Move(Vm);
        }



        //Control de Animaciones y Rotacion del Personaje

        if (vardisparo.disparo == false)
        {
            animator.SetFloat("Mov", Math.Abs(moverX) + Math.Abs(moverZ));
            animator.SetFloat("Shoot", 0);
            transform.rotation = Quaternion.Euler(
            -90,
            cam.transform.localRotation.eulerAngles.y - 180 + Input.GetAxis("Horizontal") * Convert.ToSingle(yy * (1 / (inf + Math.Abs(Input.GetAxis("Horizontal")) + Math.Abs(Input.GetAxis("Vertical"))))) * 90 - may * 180,
            0
        );

        }
        else
        {
            animator.SetFloat("Mov", 0);
            animator.SetFloat("Shoot", 1);
            transform.rotation = Quaternion.Euler(
            -90,
            cam.transform.localRotation.eulerAngles.y - 180,
            0
        );
        }
            

    }

    void Move()
    {
        
    }

    void FixedUpdate()
    {
        

            
    }
}