using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{

  
    private CharacterController Controller;
    private Vector3 move_vector;
    private float vertical_velocity;

    private bool isDead = false;

    [SerializeField]
    private float Speed;

    [SerializeField]
    private float gravity=12.0f;

    void Start()
    {
        //Screen.SetResolution(Screen.currentResolution.width / 2,Screen.currentResolution.height / 2 ,true);
        Controller = GetComponent<CharacterController>();
    }


    void Update()
    {
        if (isDead)
        {
            return;
        }
   
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

    // seviyeye göre karakter hızını arttırma
    public void SetSpeed(float difficulty_level)
    {
        Speed = 0.5f + Speed; //+ difficulty_level
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag=="virus")
        {
            Death();
        }
        else if (hit.gameObject.tag == "human")
        {
            Death();
        }

    }

    private void Death()
    {
        Debug.Log("dead");
        isDead = true;
        GetComponent<Score>().OnDeath();
    }
}
