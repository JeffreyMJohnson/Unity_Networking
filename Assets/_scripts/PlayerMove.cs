using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;

public class PlayerMove : NetworkBehaviour
{
    public GameObject bulletPrefab;

    void OnStartPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
    }

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        
        float x = Input.GetAxis("Horizontal") * .1f;
        float z = Input.GetAxis("Vertical") * .1f;
        transform.Translate(x, 0, z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireBullet();
        }
    }

    private void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position - transform.forward, Quaternion.identity)as GameObject;
        bullet.GetComponent<Rigidbody>().velocity = -transform.forward * 4;

        Destroy(bullet, 2.0f);
    }
}
