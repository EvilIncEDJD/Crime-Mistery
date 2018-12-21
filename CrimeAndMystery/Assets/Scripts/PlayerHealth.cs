using UnityEngine;
using UnityEngine.Networking;


public class PlayerHealth : NetworkBehaviour
{
    [SerializeField]
    private int maxHealth = 3;

    Player player;
    int health;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    [ServerCallback]

    private void OnEnable()
    {
        health = maxHealth;
    }

    [Server]
    public bool TakeDamage()
    {
        bool died = false;
        if (health <= 0)
            return died;

        health--;
        died = health <= 0;
        RpcTakeDamage(died);
        return died;
    }

    [ClientRpc]
    void RpcTakeDamage(bool died)
    {
        Debug.Log("damage");
        if (died)
        {
            player.Die();
        }
    }
}
