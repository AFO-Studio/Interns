using System;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    void Start()
    {

    }
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float shootForce;
    public float speed = 20.0f;
 
 void Update()
    {

        if (Input.GetButtonDown("Mouse0"))
        {
            Fire();
        }
    }
    void Fire()
    {
        var bullet = (GameObject)Instantiate(
        bulletPrefab,
        bulletSpawn.position,
        bulletSpawn.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

        Destroy(bullet, 2.0f);
    }
}