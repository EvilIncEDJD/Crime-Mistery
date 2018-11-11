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

    Vector3[] path;
    int targetIndex;

    // Update is called once per frame
    void Update()
    {

        if (sitting == true)
        {
            controller.enabled = false;
        }
        else controller.enabled = true;
        
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
        
        while (true)
        {
            PathRequestManager.RequestPath(transform.position, Closest(chair).transform.position, OnPathFound);

            if (DistanceFrom(Closest(chair)) < 2)
            {
                transform.rotation = Closest(chair).transform.rotation;
                Sit();
                //Debug.Log("i should sit");
                
                sitting = true;
            }

            else if(!sitting)
            {
                Walk();
             
              
            }
            Debug.Log("Still Chair");
            yield return new WaitForSeconds(1 / 30f);
        }
    }


    private IEnumerator AdmirePainting()
    {

        while (true)
        {
            PathRequestManager.RequestPath(transform.position, Closest(paint).transform.position, OnPathFound);

            if (DistanceFrom(Closest(paint)) < 2)
            {
                Stop();
            }
            else
            {
                Walk();
               
            }

            Debug.Log("Still paint");
            yield return new WaitForSeconds(1 / 30f);
        }
    }

    public void OnPathFound(Vector3[] newPath, bool pathSuccessful)
    {
        if (pathSuccessful)
        {
            path = newPath;
            targetIndex = 0;
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
    }

    IEnumerator FollowPath()
    {
        targetIndex = 0;
        Vector3 currentWaypoint = path[0];
        while (true)
        {
            if (transform.position == currentWaypoint)
            {
                targetIndex++;
                if (targetIndex >= path.Length)
                {
                    yield break;
                }
                currentWaypoint = path[targetIndex];
            }
            Vector3 targetDir = currentWaypoint - transform.position;
            float step = 3 * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDir);

            yield return null;

        }
    }

    public void OnDrawGizmos() {
		if (path != null) {
			for (int i = targetIndex ; i < path.Length; i ++) {
				Gizmos.color = Color.black;
				Gizmos.DrawCube(path[i], Vector3.one);

				if (i == targetIndex) {
					Gizmos.DrawLine(transform.position, path[i]);
				}
				else {
					Gizmos.DrawLine(path[i-1],path[i]);
				}
			}
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
