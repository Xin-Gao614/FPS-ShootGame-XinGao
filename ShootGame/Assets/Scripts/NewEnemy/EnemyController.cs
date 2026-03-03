using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float currentHealth = 3f;
    public float maxHealth = 3f;

    public void Update()
    {
        GetComponent<NavMeshAgent>().SetDestination(FindObjectOfType<PlayerMovement>().transform.position);
    }

    public void TakeDamage()
    {
        currentHealth -= 1f;

        if(currentHealth == 1f)
        {
            ChangeEyeColor();
        }
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    private void ChangeEyeColor()
    {
        GetComponentInChildren<SkinnedMeshRenderer>().materials[1].color = Color.red;
    }

    private void Death()
    {
        Destroy(gameObject);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            TakeDamage();
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<PlayerHealth>().TakeDamage(20);
            damageTimer = 0f;
        }
    }


    private float damageTimer = 0f;
    public float damageInterval = 1f;
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            damageTimer += Time.deltaTime;
            if(damageTimer > damageInterval)
            {
                FindObjectOfType<PlayerHealth>().TakeDamage(20);
                Debug.Log("player take damage");
                damageTimer = 0f;
            }
        }

    }

    public void OnTriggerExit(Collider other)
    {   
        if(other.gameObject.CompareTag("Player"))
        {
            damageTimer = 0f;
        }
        
    }

    


}
