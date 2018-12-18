using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveAi : MonoBehaviour
{

    // Use this for initialization
    float timer;
    Animator animator;
    GameObject[] chair, paint;
    GameObject maisPerto;
    Vector3 position, difference;
   GameObject goal;
    CharacterController controller;
    bool sitGo = false;
    bool sitting = false;
    bool walkingTo = true;
    Coroutine myCoroutine;
    
    Vector3[] path;
    int targetIndex;
    NavMeshAgent agent ;
    // Update is called once per frame
    void Update()
    {

        if (sitting == true)
        {
            controller.enabled = false;
            agent.enabled = false;
        }
        else 
        {
            controller.enabled = true;
            agent.enabled = true;
        }
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
         agent = GetComponent<NavMeshAgent>();
        StartCoroutine(DoSomething());
    }

    IEnumerator DoSomething()
    {



        while (true)
        {
            timer = Random.Range(5, 10);
            int x = Random.Range(0, 0);

            switch (x)
            {

                case 0:
                    {
                       myCoroutine = StartCoroutine(goSit());
                       
                    }
                    break;
               case 1:
                    {                       
                        sitting = false;
                        myCoroutine = StartCoroutine(AdmirePainting());                      
                    }
                    break;

            }
           
            yield return new WaitForSeconds(10);

            StopCoroutine(myCoroutine);
        }
    }


    private IEnumerator goSit()
    {
        goal = Closest(chair);
        while (true)
        {
            
            if (DistanceFrom(goal) < 0.5)
            {
                transform.rotation = goal.transform.rotation;
                Sit();
                //Debug.Log("i should sit");
                
                sitting = true;
            }

            else if(!sitting)
            {
                agent.destination = goal.transform.position;
                Walk();
             
              
            }
            Debug.Log("Still Chair");
            yield return new WaitForSeconds(1 / 30f);
        }
    }


    private IEnumerator AdmirePainting()
    {
        goal = Closest(paint);
        while (true)
        {
          
            if (DistanceFrom(goal) < 1)
            {
                Stop();
            }
            else
            {
                 agent.destination = goal.transform.position;
                Walk();
               
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
