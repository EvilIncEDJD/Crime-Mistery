using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAi : MonoBehaviour
{

    // Use this for initialization
    float timer;
    public Animator animator;
    GameObject[] chair, paint;
    GameObject maisPerto;
    Vector3 position, difference;
   
    CharacterController controller;
    bool sitGo = false;
    bool sitting = false;
    bool walkingTo = true;
    Coroutine myCoroutine;
   
    // Update is called once per frame
    void Update()
    {
        // controller.SimpleMove(Vector3.forward);
        /* if(sitGo == true)
          {
              goSit();

          }
         else if(Gopaint == true)
          {
              AdmirePainting();
          }*/

        
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        //Debug.Log("maisPerto" + maisPerto.tag);
    }

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        position = transform.position;
        chair = GameObject.FindGameObjectsWithTag("Chair");
        paint = GameObject.FindGameObjectsWithTag("Painting");

        StartCoroutine(DoSomething());
    }

    IEnumerator DoSomething()
    {



        while (true)
        {
            timer = Random.Range(5, 10);
            int x = Random.Range(0, 2); 

            switch (x)
            {

                case 0:
                    {
                       myCoroutine = StartCoroutine(goSit());
                        sitting = false;
                       
                        //StopCoroutine(myCoroutine);


                    }
                    break;
               case 1:
                    {
                        myCoroutine = StartCoroutine(AdmirePainting());
                       // StopCoroutine(myCoroutine);
                    }
                    break;

            }
           
            yield return new WaitForSeconds(10);

            StopCoroutine(myCoroutine);
        }
    }


    private IEnumerator goSit()
    {
        while (true)
        {
            if (DistanceFrom(Closest(chair)) < 0.5)
            {
                transform.rotation = Closest(chair).transform.rotation;
                Sit();
                //Debug.Log("i should sit");
                
                sitting = true;
            }

            else if(!sitting)
            {
                Walk();
                RotateTo(Closest(chair));
              
            }
            Debug.Log("Still Chair");
            yield return new WaitForSeconds(1 / 30f);
        }
    }


    private IEnumerator AdmirePainting()
    {
        while (true)
        {
            if (DistanceFrom(Closest(paint)) < 2)
            {
                Stop();

            }
            else
            {
                Walk();
                RotateTo(Closest(paint));
               

            }
            Debug.Log("Still paint");
            yield return new WaitForSeconds(1 / 30f);
        }
    }


    public GameObject Closest(GameObject[] gameObjects)
    {
     
       
        float estaDistancia =  Mathf.Infinity;
        float distance = Mathf.Infinity;

        foreach (GameObject go in gameObjects)
        {
            //Debug.Log("ob entry-> "+go.tag);
            estaDistancia = DistanceFrom(go);

            if (estaDistancia < distance)
            {
                maisPerto = go;
               // Debug.Log("aqui" + maisPerto.tag);
                distance = estaDistancia;
            }
        }

        return maisPerto;
    }

    public Vector3 MoveToward(GameObject go)
    {
        Vector3 goToObjective = go.transform.position - transform.position;
        goToObjective.y = 0;

       
        return goToObjective;
    }

    public Quaternion RotateTo(GameObject go)
    {
        //Debug.Log("tag" + go.transform.tag);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(MoveToward(go), Vector3.up), 3 * Time.deltaTime);
        //Debug.Log(go.transform.tag);
        return transform.rotation;
    }

    public float DistanceFrom(GameObject go)
    {

        float distance = Vector3.Distance(transform.position, go.transform.position);
        return distance;
    }

    public void Walk()
    {
        animator.Play("Walk");
    }

    public void Stop()
    {
        animator.Play("Idle");
    }

    public void Sit()
    {
        animator.Play("Sit");
    }
}
