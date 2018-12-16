using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Saude : NetworkBehaviour  {
 	
	  [SyncVar]
	//public const int maxHealth = 100;
    public int currentHealth = 1;

	private NetworkStartPosition [] spawnPoints;

	void Start ()	
	{
		if (isLocalPlayer)
		{
            spawnPoints = FindObjectsOfType <NetworkStartPosition> ();
		}
	}

   public void TakeDamage(int amount)
    {
		 if (!isServer)
        {
            return;
        }

        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
			//animation.SetBool("Dead", true);
            Debug.Log("E morreu!");
			//RpcRespawn();
        }
    }

	 [ClientRpc]
    void RpcRespawn()
    {
        if (isLocalPlayer)
        {
            // Defina o ponto de origem como origem como um valor padrão
            Vector3 spawnPoint = Vector3.zero;

			// Se houver uma matriz de ponto de spawn e a matriz não estiver vazia, escolha um ponto de spawn aleatoriamente
            if (spawnPoints != null && spawnPoints.Length > 0)
            {
                spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            }

			// Defina a posição do jogador para o ponto de desova escolhido
            transform.position = spawnPoint;
        }
    }
}
