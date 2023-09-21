using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int EHealth;
    public int EMaxHealth = 3;
    public int playerDamage = 1;




    // public GameObject enemyHeart;
    // public GameObject enemyHeart1;
    // public GameObject enemyHeart2;
    //  private List<GameObject> enemyHearts;



    void Start()
    {
        EHealth = EMaxHealth;
        //UpdateKillCountText();


        //enemyHearts = new List<GameObject> { enemyHeart, enemyHeart1, enemyHeart2 };
        /*UpdateEnemyHearts();

        // Activate the appropriate number of enemy hearts based on initial health
        for (int i = 0; i < enemyHealth; i++)
        {
            enemyHearts[i].SetActive(true);
        }*/

    }


    // Update is called once per frame
    void Update()
    {
        if (EHealth <= 0)
        {
            Die();
        }


        EnemyHurt();

    }

    private void Die()
    {
        Destroy(gameObject);

    }



    public void EnemyHurt()
    {
        EHealth--;


    }
}
