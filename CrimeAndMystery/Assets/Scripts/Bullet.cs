using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class Bullet : NetworkBehaviour
{
    private Vector3 position;
    private Vector3 direction;
    private const float apliedForce = 20;
    public float dyingTime;
    

    public Bullet(Vector3 position, Vector3 direction, float dyingTime)
    {
        this.position = position;
        this.direction = direction;
        this.dyingTime = dyingTime;

    }

    public void ApplyForce()
    {
        Debug.DrawRay(position, direction, Color.black, dyingTime);
        //transform.position += transform.forward;
    }

    public void BulletDeath(float elapsedTime)
    {
        if (elapsedTime > dyingTime)
        {
            transform.position = position;
        }
    }
}


