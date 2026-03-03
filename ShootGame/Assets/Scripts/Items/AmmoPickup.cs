using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] private int ammoAmount = 20;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("pick up ammo");
            FindObjectOfType<PlayerHealth>().currentAmmo += ammoAmount;
            FindObjectOfType<PlayerHealth>().UpdateAmmo();
            Destroy(gameObject);
        }
    }

}
