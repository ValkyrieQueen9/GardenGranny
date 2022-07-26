using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public float speed;

    private Rigidbody2D rb;
    private Vector2 moveVector;
    
    void Start()
    { 
       rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       moveVector = Vector2.zero;

        //BACKWARD W
        if (Input.GetKey(KeyCode.W))
        {
            moveVector.y += 1;
            animator.SetBool("Backward", true);
                if (Input.GetKey(KeyCode.Space))
                {
                    animator.SetBool("HitBackward", true);
                }
        }

             if (!Input.GetKey(KeyCode.W))
              {
                animator.SetBool("Backward", false);
              }
                if (!Input.GetKey(KeyCode.Space))
                {
                    animator.SetBool("HitBackward", false);
                }

        //LEFT A
        if (Input.GetKey(KeyCode.A))
        {
            moveVector.x += -1;
            animator.SetBool("Left", true);
                if (Input.GetKey(KeyCode.Space))
                {
                    animator.SetBool("HitLeft", true);
                }
        }

             if (!Input.GetKey(KeyCode.A))
              {
                animator.SetBool("Left", false);
              }
                if (!Input.GetKey(KeyCode.Space))
                {
                    animator.SetBool("HitLeft", false);
                }


        //FORWARD S
        if (Input.GetKey(KeyCode.S))
        {
            moveVector.y += -1;
            animator.SetBool("Forward", true);
                if (Input.GetKey(KeyCode.Space))
                {
                    animator.SetBool("Hit", true);
                }
                
        }

            if (!Input.GetKey(KeyCode.S))
            {
                animator.SetBool("Forward", false);
            }
            if (!Input.GetKey(KeyCode.Space))
            {
                animator.SetBool("Hit", false);
            }

        //RIGHT D
        if (Input.GetKey(KeyCode.D))
        {
            moveVector.x += 1;
            animator.SetBool("Right", true);
                if (Input.GetKey(KeyCode.Space))
                {
                    animator.SetBool("HitRight", true);
                }
        }
            if (!Input.GetKey(KeyCode.D))
            {
                animator.SetBool("Right", false);
            }
            if (!Input.GetKey(KeyCode.Space))
            {
                animator.SetBool("HitRight", false);
            }

        //Idle hit
        if (Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Hit", true);
        }
        if (!Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("Hit", false);
        }

        rb.transform.position += new Vector3(moveVector.x * speed, moveVector.y * speed, 0) * speed * Time.deltaTime;
    }
}
