using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pcontroller : MonoBehaviour {

    public Animator animator;
    private CharacterController _characterController;
    private float speed = 3.2f;
    public float rotationSpeed = 100.0f;
    
    

    void Start () {       
        animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
    }    
    void Update() {


        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
            if (Input.GetAxis("Vertical") > 0 )
            {
                animator.SetBool("isWalking", true);

                    if (Input.GetButton("Crouch") == true)
                    {
                        animator.SetBool("isCrouched", Input.GetButton("Crouch"));
                        _characterController.height = 1.0f;
                        _characterController.center = new Vector3(0.0f, 0.5f, 0.0f);
                    }
                    else
                    {
                        animator.SetBool("isCrouched", false);
                        _characterController.height = 1.85f;
                        _characterController.center = new Vector3(0.0f, 0.93f, 0.0f);
                    }
                    transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
        }
            else
            {
                animator.SetBool("isWalking", false);
            }
            animator.SetBool("isRunning", Input.GetButton("Run"));
            animator.SetFloat("direction", Input.GetAxis("Horizontal"));
        



    }



}
