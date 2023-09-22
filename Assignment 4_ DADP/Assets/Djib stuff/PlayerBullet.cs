using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    EnemyStats enemyController;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // If the player has a PlayerStats component, apply damage.
            PlayerBullet glock = collision.gameObject.GetComponent<PlayerBullet>();
            if (enemyController != null)
            {
                enemyController.EnemyHurt();
            }
        }
    }
}
