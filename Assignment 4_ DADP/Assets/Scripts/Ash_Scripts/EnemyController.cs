using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class EnemyController : MonoBehaviour
{
    public float lookradius = 10f;

    Transform target;

    NavMeshAgent agent;


    private void Start()
    {
        target = PlayerManager.instance.player.transform; 
        agent = GetComponent<NavMeshAgent>(); 
    }

    private void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position); 

        if(distance <= lookradius)
        {
            agent.SetDestination(target.position); 

            if (distance <= agent.stoppingDistance)
            {
                //attack the player 
                FaceTarget(); 
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Assuming the enemy does 10 damage to the player on collision
            PlayerManager.instance.TakeDamage(10);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookradius);
    }





}
