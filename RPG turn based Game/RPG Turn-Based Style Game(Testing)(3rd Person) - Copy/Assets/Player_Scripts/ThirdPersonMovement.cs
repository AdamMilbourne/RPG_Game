using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform camera;
    private Animator anim;

    public float speed = 6f;

    public float turnsmoothtime = 0.1f;
    float turnsmoothVelocity;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnsmoothVelocity, turnsmoothtime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 movedirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(movedirection.normalized * speed * Time.deltaTime);


        }

      if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
           
            anim.SetBool("IsWalking", true);
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                speed = 14f;
                anim.SetBool("IsRunning", true);
            }
            else if(Input.GetKeyUp(KeyCode.LeftShift))
            {
                anim.SetBool("IsRunning", false);
                speed = 6f;
            } 
        }
        else
        {
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsRunning", false);      
        }






      /*  if(Input.GetKey(KeyCode.S))
        {
            speed = 5f;
            anim.SetBool("WalkingBack", true);
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                speed = 10f;
                anim.SetBool("RunningBack", true);
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                anim.SetBool("RunningBack", false);
                speed = 5f;
            }
        }
        else
        {
            anim.SetBool("WalkingBack", false);
            anim.SetBool("RunningBack", false);
        }*/
    }
}
     