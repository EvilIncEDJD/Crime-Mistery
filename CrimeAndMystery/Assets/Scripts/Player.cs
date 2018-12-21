using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

//Toggle events local e remote ou para todos
[System.Serializable]
public class ToggleEvent : UnityEvent<bool> { }
public class Player : NetworkBehaviour
{

    [SerializeField] ToggleEvent onToggleShare;
    [SerializeField] ToggleEvent onToggleLocal;
    [SerializeField] ToggleEvent onToggleRemote;
    [SerializeField] float timeRespawn = 1f;

    GameObject mainCamera;


    private void Start()
    {
        mainCamera = Camera.main.gameObject;
        EnablePlayer();
    }

    private void EnablePlayer()
    {
        onToggleShare.Invoke(true);

        if (isLocalPlayer)
        {
            mainCamera.SetActive(false);
            onToggleLocal.Invoke(true);
        }
        else
            onToggleRemote.Invoke(true);
    }

    private void DisablePlayer()
    {
        onToggleShare.Invoke(false);

        if (isLocalPlayer)
        {
            mainCamera.SetActive(true);
            onToggleLocal.Invoke(false);
        }
        else
            onToggleRemote.Invoke(false);
    }

    public void Die()
    {
        DisablePlayer();
        Debug.Log("die");
        Invoke("Respawn", timeRespawn);
    }

    void Respawn()
    {
        if(isLocalPlayer)
        {
            Transform spawn = NetworkManager.singleton.GetStartPosition();
            transform.position = spawn.position;
            transform.rotation = spawn.rotation;
        }
        EnablePlayer();
    }
}
