using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Enemies : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;

    public float movementSpeed = 3f;

    //public GameObject damageTextPrefab;
    //public GameObject ParticlePrefab;

    private Transform target;
    //public ShopManager shopManager;

    public float maxOffset = 0.5f;
    private Vector2 offset;



    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth;


        //shopManager = GameObject.FindGameObjectWithTag("ShopManager").GetComponent<ShopManager>();

        offset = new Vector2(Random.Range(-maxOffset, maxOffset), Random.Range(-maxOffset, maxOffset));
    }

    private void Update()
    {
        if (target != null)
        {
            // (Attack the main character)
            Vector3 direction = ((target.position + (Vector3)offset) - transform.position).normalized;


            transform.Translate(direction * movementSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {

            //shopManager.dollars += 2;
            //shopManager.UpdateDollarsText();//(Updates the money the player has) */


           /* if (ParticlePrefab != null)
            {
                Instantiate(ParticlePrefab, transform.position, Quaternion.identity);
            }

            Destroy(gameObject); //This destroys the enemy 
        }


        if (damageTextPrefab != null)
        {

            GameObject damageTextGO = Instantiate(damageTextPrefab, transform.position, Quaternion.identity);
            Text damageText = damageTextGO.GetComponent<Text>();
            damageText.text = damage.ToString();


            StartCoroutine(DestroyDamageTextAfterDelay(damageTextGO)); */
        }
    } 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            int randomDamage = Random.Range(1, 6);


            /*PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(randomDamage);
            } */
        }
        else if (other.CompareTag("Projectile"))
        {

            int randomDamage = Random.Range(1, 6);


            TakeDamage(randomDamage);

            Destroy(other.gameObject);
        }
    }


    private IEnumerator DestroyDamageTextAfterDelay(GameObject damageTextGO)
    {

        yield return new WaitForSeconds(2f);


        Destroy(damageTextGO);
    }
}