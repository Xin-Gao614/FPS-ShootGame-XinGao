using UnityEngine;

public class HPPickup : MonoBehaviour
{
    [SerializeField] private int hpAmount = 40;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<PlayerHealth>().currentHealth += hpAmount;
            FindObjectOfType<PlayerHealth>().UpdateHealth();
            Destroy(gameObject);
        }
    }
}
