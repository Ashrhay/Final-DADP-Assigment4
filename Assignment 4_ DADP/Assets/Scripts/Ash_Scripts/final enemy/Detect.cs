using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect : MonoBehaviour
{

    bool dectected;
    GameObject player;
    public Transform enemy;

    public GameObject bullet;
    public Transform shootPoint;

    public float shootSpeed = 10f;
    public float timeToShoot = 1.3f;
    float originalTime; 

    // Start is called before the first frame update
    void Start()
    {
        originalTime = timeToShoot; 
    }

    // Update is called once per frame
    void Update()
    {
        if (dectected)
        {
            enemy.LookAt(player.transform); 
        }
    }

    private void FixedUpdate()
    {
        if (dectected)
        {
            timeToShoot -= Time.deltaTime; 

            if(timeToShoot < 0)
            {
                ShootPlayer();
                timeToShoot = originalTime; 
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            dectected = true;
            player = other.gameObject; 
        }
    }

    private void ShootPlayer()
    {
        GameObject currentBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        Rigidbody rig = currentBullet.GetComponent<Rigidbody>();

        rig.AddForce(transform.forward * shootSpeed, ForceMode.VelocityChange);

        //detroying the bullet. 
        Destroy(currentBullet, 2f); 
    } 
}
