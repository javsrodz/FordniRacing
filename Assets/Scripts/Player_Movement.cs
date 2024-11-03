using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed = 0.5f;
    public float rotationspeed = 5f; // Ajuste de velocidad de rotaci�n

    // Update is called once per frame
    void Update()
    {
        Movement();
        Clamp();
    }

    void Movement()
    {
        // Movimiento hacia la derecha
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -47), rotationspeed * Time.deltaTime);
        }
        // Movimiento hacia la izquierda
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 47), rotationspeed * Time.deltaTime);
        }
        // Volver a rotaci�n neutra cuando no hay entrada
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), rotationspeed * Time.deltaTime);
        }
    }

    void Clamp()
    {
        // Limitar la posici�n en el eje x
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -1.7f, 1.7f); // Rango m�s amplio
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Cars")
        {
            Time.timeScale = 0;
        }
    }
}
