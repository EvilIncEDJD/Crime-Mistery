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
            if (Input.GetAxis("Vertical") > 0)
            {
                animator.SetBool("isWalking", true);
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
