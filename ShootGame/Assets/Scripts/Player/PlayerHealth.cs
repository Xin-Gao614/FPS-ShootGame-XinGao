using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    // player hp
    public float currentHealth = 100f;
    public float maxHealth = 100f;


    // player ammo
    public int currentAmmo = 100;

    void Start ()
    {
        FindObjectOfType<UIController>().UpdateHP(currentHealth);
        FindObjectOfType<UIController>().UpdateAmmo(currentAmmo);
    }


public void UpdateHealth()
    {
        FindObjectOfType<UIController>().UpdateHP(currentHealth/maxHealth);
    }

    public void UpdateAmmo()
    {
        FindObjectOfType<UIController>().UpdateAmmo(currentAmmo);
    }


    public void TakeDamage (int amount)
    {
        currentHealth -= amount;

        if(currentHealth <= 0)
        {
            FindObjectOfType<UIController>().ShowGameOver();
        }
        UpdateHealth();
    }

    void Death ()
    {

    }

    public void RestartLevel ()
    {

    }
}
