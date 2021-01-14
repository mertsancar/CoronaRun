using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
  
    private CharacterController Controller;
    private Vector3 move_vector;
    private float vertical_velocity;



    [SerializeField]
    private float Speed;

    [SerializeField]
    private float gravity=12.0f;

    void Start()
    {
        Controller = GetComponent<CharacterController>();
    }


    void Update()
    {
   
        move_vector = Vector3.zero;
        Gravity();
        Forward();
    }

    void Gravity()
    {
        if (Controller.isGrounded)
        {
            vertical_velocity = -0.5f;
        }
        else
        {
            vertical_velocity -= gravity * Time.deltaTime;
        }
        // aşağı yukarı (Y)
        move_vector.y = vertical_velocity;
    }
    void Forward()
    {


        // Sağ Sol (X)
        move_vector.x = Input.GetAxisRaw("Horizontal") * Speed;

        // telefon ekranı için
        if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x > Screen.width/2)
            {
                move_vector.x = Speed;
            }
            else
            {
                move_vector.x = -Speed;
            }
        }

        // İleri (Z)
        move_vector.z = Speed;

        Controller.Move((move_vector * Speed) * Time.deltaTime);
    }

    public void SetSpeed(float difficulty_level)
    {
        Speed = 0.5f + Speed; //+ difficulty_level
    }

}
