using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int damage = 1;
    public float range = 100f;

    
    public ParticleSystem muzzelFlash;
    public Camera fpscam;
    public GameObject bulletPrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
            
        }
    }

    void Shoot()
    {
        muzzelFlash.Play();


        RaycastHit hit;
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);
            EnemyManager target = hit.transform.GetComponent<EnemyManager>();

            if (target != null)
            {
                target.EnemyHurt();
            }
            if (hit.rigidbody != null)
            {

            }

            GameObject bullet = Instantiate(bulletPrefab, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(bullet, 2);
        }
    }
}
