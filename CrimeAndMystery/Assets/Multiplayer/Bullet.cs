using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	void OnCollisionEnter(Collision collision)
    {
        var hit = collision.gameObject;
        var vida = hit.GetComponent<Saude>();
        if (vida  != null)
        {
            vida.TakeDamage(1);
        }

        Destroy(gameObject);
    }
}
