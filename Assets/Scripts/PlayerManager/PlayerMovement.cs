using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public GameObject model;

    public Animator anim;
    public float speed = 3;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {   
        Vector3 movementDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        rb.velocity = movementDirection * speed;
        Quaternion toRotation = Quaternion.LookRotation(movementDirection , Vector3.up);
        if (Quaternion.Angle(transform.rotation, toRotation) > 0.1f)
        {
            // Rotate the object to face the movement direction
            model.transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 360 );
        }


        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {

            if (GameManager.Instance.Pizza > 0)
            {
                anim.SetBool("WalkWithPizza", true);
                anim.SetBool("Walk", false);
                anim.SetBool("Stay", false);


            }
            else
            {

            anim.SetBool("Walk", true);
            anim.SetBool("WalkWithPizza", false);
            anim.SetBool("Stay", false);
            }

        }
        else
            anim.SetBool("Stay", true);
   

    }
}
