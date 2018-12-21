using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnPositionDefinition : MonoBehaviour
{

    private Transform[] spawnPositions;

    void Start()
    {
        spawnPositions = GetComponentsInChildren<Transform>();
        SpawnPositions();
    }

    private void SpawnPositions()
    {
        for (int i = 0, j = spawnPositions.Length - 1; i < spawnPositions.Length; i++, j--)
        {
            if (i == 0)
                continue;
            if (i % 2 == 0)
                spawnPositions[i].position = new Vector3(transform.position.x + i, 2, transform.position.z + j);
            else
                spawnPositions[i].position = new Vector3(transform.position.x + j, 2, transform.position.z + i);


        }
    }
}
