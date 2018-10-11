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
    void Update()
    {


        /*  float translation = Input.GetAxis("Vertical") * speed;
          float rotation = Input.GetAxis("Horizontal") * rotationSpeed;*/

          //Anda pro lado esquerdo, chamado strafe
        if (Input.GetAxis("Horizontal") < 0)
        {
           animator.SetBool("isLeft", true);

        }
        //Anda pro lado direito
        else if (Input.GetAxis("Horizontal") > 0)
        {
          
          animator.SetBool("isRight", true);

        }
        
        else
        {
            animator.SetBool("isLeft", false);
            animator.SetBool("isRight", false);
        }

        //Se andar pra frente
        if (Input.GetAxis("Vertical") > 0 )
            {
            animator.SetBool("leftTurn", false);
            animator.SetBool("rightTurn", false);

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

    //Anda pra tras
            else if (Input.GetAxis("Vertical") < 0)
            {

            animator.SetBool("leftTurn", false);
            animator.SetBool("rightTurn", false);

            animator.SetBool("isWalkBack", true);

            transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
        }

      //        Se não estiver a andar pra frente, nem pra tras
        else if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
        {

            animator.SetBool("isWalkBack", false);
            animator.SetBool("isWalking", false);
            //Se andar com o rato pra esquerda,  animação de virar pra esquerda
            if (Input.GetAxis("Mouse X") < 0)
            {
                animator.SetBool("leftTurn", true);
            }  //Se andar com o rato pra direita, animação de virar pra direita

            else if (Input.GetAxis("Mouse X") > 0)
            {
                animator.SetBool("rightTurn", true);

            }
            else
            {
                animator.SetBool("leftTurn", false);
                animator.SetBool("rightTurn", false);

            }
        }

         

        animator.SetBool("isRunning", Input.GetButton("Run"));
            animator.SetFloat("direction", Input.GetAxis("Horizontal"));
        



    }



}
