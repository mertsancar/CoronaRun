using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    private Transform look_at;
    private Vector3 start_off_set;
    private Vector3 move_vector;

    private float transition = 0.0f;
    private float animation_duration = 2.0f;
    private Vector3 animation_off_set = new Vector3(0, 5, 5);
    void Start()
    {
        look_at = GameObject.FindGameObjectWithTag("Player").transform;
        start_off_set = transform.position - look_at.position;
        // transform.position kameranın pozisyonu oluyor
    }

    
    void Update()
    {
        Camera_Move();
    }

    void Camera_Move()
    {
        move_vector = look_at.position + start_off_set;

        //X
        move_vector.x = 3;
        //Y
        move_vector.y = Mathf.Clamp(move_vector.y, 3, 5);

        if (transition > 1.0f)
        {
            transform.position = move_vector;
        }
        else
        {
            //Başlangıç animasyonu
            transform.position = Vector3.Lerp(move_vector + animation_off_set, move_vector, transition);
            transition += Time.deltaTime * 1 / animation_duration;
        }


    }
}
