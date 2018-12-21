using UnityEngine;
using UnityEngine.Networking;

public class PlayerShooting : NetworkBehaviour
{
    [SerializeField] float coolDown = 0.3f;
    [SerializeField] Transform shootTransform;

    private float elapsedTime;
    private bool canShoot;

    private void Start()
    {
        if (isLocalPlayer)
            canShoot = true;
    }

    private void Update()
    {
        if (!canShoot)
            return;

        elapsedTime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Mouse0) && elapsedTime > coolDown)
        {
            elapsedTime = 0;
            CmdFire(shootTransform.position, shootTransform.forward, elapsedTime);
        }

    }

    [Command]
    void CmdFire(Vector3 origin, Vector3 direction, float elapsedTime)
    {
        RaycastHit hit;
        Debug.DrawRay(origin, direction * 3f, Color.green);
        Ray ray = new Ray(origin, direction);

        bool result = Physics.Raycast(ray, out hit, 50f);

        if (result)
        {
            PlayerHealth enemy = hit.transform.GetComponent<PlayerHealth>();
            if (enemy)
                enemy.TakeDamage();
        }

        RpcShowShot(origin, direction, elapsedTime);
    }

    [ClientRpc]
    void RpcShowShot(Vector3 origin, Vector3 direction, float elapsedTime)
    {
        Debug.DrawRay(origin, direction, Color.black, elapsedTime);

        //Bullet shot = new Bullet(origin, direction, 0.3f);
        //shot.ApplyForce();
        //shot.BulletDeath(elapsedTime);

    }
}

