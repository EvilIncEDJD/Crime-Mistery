using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RotationAround : NetworkBehaviour {

    private RaycastHit hit;
    private Vector3 lastPosition, actualPosition;
    private int toggle;

    public void Start()
    {
        toggle = 1;
        hit = new RaycastHit();
        actualPosition = new Vector3();
        actualPosition = transform.position;
        lastPosition = actualPosition;
    }

    void Update () {
        actualPosition = transform.position;
        RpcRotateobject();
        lastPosition = actualPosition;
    }

    [ClientRpc]
    private void RpcRotateobject()
    {
        
        if (Physics.Raycast(transform.position, -transform.up , out hit, 100)&& isLocalPlayer)
        {
            
            actualPosition +=  Input.GetAxis("Vertical")* transform.forward.normalized ;
            transform.position = Vector3.Lerp(lastPosition, actualPosition, 0.5f);
        }
        
    }
}
