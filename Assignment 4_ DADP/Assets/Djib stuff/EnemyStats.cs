using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int EHealth;
    public int EMaxHealth = 3;
    public int playerDamage = 1;

    void Start()
    {
        EHealth = EMaxHealth;

    }
    // Update is called once per frame
    void Update()
    {
        if (EHealth <= 0)
        {
            Die();
        }


    }

    private void Die()
    {
        Destroy(gameObject);
        //IncreaseKillCount();
    }



    public void EnemyHurt()
    {
        EHealth--;
     if(EHealth <= 0)
        {
            Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "bullet")
        {
            EnemyHurt();
        }
    }
}
